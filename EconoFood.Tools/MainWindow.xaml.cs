using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EconoFood.Tools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            var caminhoPadrao = @"C:\DataBase\";
            SqlConnection connection = new SqlConnection(@"Server=THIAGO-PC\SQLEXPRESS; user id=sa; password=123321; DataBase=EconoFood");
            connection.Open();
            var Tables = connection.GetSchema("Tables");            
            StringBuilder Procedures = new StringBuilder();

            foreach (DataRow item in Tables.Rows)
            {
                var nomeTabela = item.ItemArray[2].ToString();                
                string[] restrictions = new string[4] { null, null, nomeTabela, null };
                var colunas = connection.GetSchema("Columns", restrictions).AsEnumerable().Select(s => s.Field<String>("Column_Name")).ToList();
                var colunasTipadas = connection.GetSchema("Columns", restrictions);

                #region [ INSERT ] 
                Procedures.AppendLine(" USE ECONOFOOD ");
                Procedures.AppendLine(" GO ");
                Procedures.AppendLine(string.Format("CREATE PROCEDURE {0}_INSERT ", nomeTabela));
                Procedures.AppendLine("( ");

                //1 parâmetro para cada coluna, menos para a primeira que é PK.
                for (int i = 0; i < colunas.Count; i++)
                {
                    if (colunas[i] == colunas.First())
                        continue;

                    var tipoColuna = colunasTipadas.AsDataView().ToTable().Rows[i].ItemArray[7];
                    var tamanhoColuna = colunasTipadas.AsDataView().ToTable().Rows[i].ItemArray[8];
                    if (tipoColuna.ToString().ToLower() != "varchar")
                        Procedures.AppendLine(string.Format(" @{0} {1}", colunas[i], tipoColuna));
                    else
                        Procedures.AppendLine(string.Format("@{0} {1}({2})", colunas[i], tipoColuna, tamanhoColuna.ToString() == "-1" ? "MAX" : tamanhoColuna));
                    if (colunas[i] != colunas.Last())
                        Procedures.Append(",");
                }

                Procedures.AppendLine(") ");
                Procedures.AppendLine(" AS ");
                Procedures.AppendLine(" BEGIN ");
                Procedures.AppendLine(" SET NOCOUNT ON; ");
                Procedures.AppendLine(string.Format("INSERT INTO {0} (", nomeTabela));
                for (int i = 0; i < colunas.Count; i++)
                {
                    if (colunas[i] == colunas.First())
                        continue;

                    Procedures.AppendLine(string.Format("{0}", colunas[i]));
                    if (colunas[i] != colunas.Last())
                        Procedures.Append(",");
                }
                Procedures.AppendLine(" ) ");
                Procedures.AppendLine(" VALUES( ");
                //1 parâmetro para cada coluna, menos para a primeira que é PK.
                for (int i = 0; i < colunas.Count; i++)
                {
                    if (colunas[i] == colunas.First())
                        continue;

                    Procedures.AppendLine(string.Format("@{0}", colunas[i]));
                    if (colunas[i] != colunas.Last())
                        Procedures.Append(",");
                }
                Procedures.AppendLine(") ");
                Procedures.AppendLine(" SELECT @@IDENTITY");
                Procedures.AppendLine(" END");
                #endregion
                
                var arquivo_INSERT = File.Create(caminhoPadrao + string.Format("{0}_INSERT.sql", nomeTabela));
                StreamWriter arquivo = new StreamWriter(arquivo_INSERT);
                arquivo.Write(Procedures.ToString());
                arquivo.Flush();
                arquivo.Dispose();
                Procedures = new StringBuilder();

                #region [ DELETE ]
                Procedures.AppendLine(" USE ECONOFOOD ");
                Procedures.AppendLine(" GO ");
                Procedures.AppendLine(string.Format(" CREATE PROCEDURE {0}_DELETE", nomeTabela));
                Procedures.AppendLine(" (");
                //parâmetro para a primeira coluna que é PK.
                for (int i = 0; i < colunas.Count; i++)
                {
                    if (colunas[i] == colunas.First())
                    {
                        var tipoColuna = colunasTipadas.AsDataView().ToTable().Rows[i].ItemArray[7];
                        var tamanhoColuna = colunasTipadas.AsDataView().ToTable().Rows[i].ItemArray[8];
                        if (tipoColuna.ToString().ToLower() != "varchar")
                            Procedures.AppendLine(string.Format(" @{0} {1}", colunas[i], tipoColuna));
                        else
                            Procedures.AppendLine(string.Format("@{0} {1}({2})", colunas[i], tipoColuna, tamanhoColuna.ToString() == "-1" ? "MAX" : tamanhoColuna));
                    }

                    break;
                }
                Procedures.AppendLine(" ) ");
                Procedures.AppendLine(" AS ");
                Procedures.AppendLine(" BEGIN ");
                Procedures.AppendLine(" SET NOCOUNT ON; ");                
                Procedures.AppendLine(string.Format(" DELETE FROM {0} ", nomeTabela));
                Procedures.AppendLine(string.Format(" WHERE {0}=@{1} ", colunas.First(), colunasTipadas.AsDataView().ToTable().Rows[0].ItemArray[3]));
                Procedures.AppendLine(" END ");
                #endregion

                var arquivo_DELETE = File.Create(caminhoPadrao + string.Format("{0}_DELETE.sql", nomeTabela));
                arquivo = new StreamWriter(arquivo_DELETE);
                arquivo.Write(Procedures.ToString());
                arquivo.Flush();
                arquivo.Dispose();
                Procedures = new StringBuilder();

                #region [ SELECT ALL ]
                Procedures.AppendLine(" USE ECONOFOOD ");
                Procedures.AppendLine(" GO ");
                Procedures.AppendLine(string.Format(" CREATE PROCEDURE {0}_SELECT_ALL", nomeTabela));
                Procedures.AppendLine(" AS ");
                Procedures.AppendLine(" BEGIN ");
                Procedures.AppendLine(" SET NOCOUNT ON; ");
                Procedures.AppendLine(" SELECT ");
                //1 parâmetro para cada coluna
                for (int i = 0; i < colunas.Count; i++)
                {
                    Procedures.AppendLine(string.Format(" {0} ", colunas[i]));
                    if (colunas[i] != colunas.Last())
                        Procedures.Append(",");
                }
                Procedures.AppendLine(string.Format(" FROM {0}", nomeTabela));
                Procedures.AppendLine(" END ");
                #endregion

                var arquivo_SELECT_ALL = File.Create(caminhoPadrao + string.Format("{0}_SELECT_ALL.sql", nomeTabela));
                arquivo = new StreamWriter(arquivo_SELECT_ALL);
                arquivo.Write(Procedures.ToString());
                arquivo.Flush();
                arquivo.Dispose();
                Procedures = new StringBuilder();

                #region [ SELECT ]
                Procedures.AppendLine(" USE ECONOFOOD ");
                Procedures.AppendLine(" GO ");
                Procedures.AppendLine(string.Format(" CREATE PROCEDURE {0}_SELECT ", nomeTabela));
                Procedures.AppendLine(" ( ");
                //1 parâmetro para cada coluna
                for (int i = 0; i < colunas.Count; i++)
                {
                    var tipoColuna = colunasTipadas.AsDataView().ToTable().Rows[i].ItemArray[7];
                    var tamanhoColuna = colunasTipadas.AsDataView().ToTable().Rows[i].ItemArray[8];
                    if (tipoColuna.ToString().ToLower() != "varchar")
                        Procedures.AppendLine(string.Format(" @{0} {1}", colunas[i], tipoColuna));
                    else
                        Procedures.AppendLine(string.Format("@{0} {1}({2})", colunas[i], tipoColuna, tamanhoColuna.ToString() == "-1" ? "MAX" : tamanhoColuna));

                    if (colunas[i] != colunas.Last())
                        Procedures.AppendLine(",");
                }
                Procedures.AppendLine(" ) ");
                Procedures.AppendLine(" AS ");
                Procedures.AppendLine(" BEGIN ");
                Procedures.AppendLine(" SET NOCOUNT ON; ");
                Procedures.AppendLine(" SELECT ");
                //1 parâmetro para cada coluna
                for (int i = 0; i < colunas.Count; i++)
                {
                    Procedures.AppendLine(string.Format(" {0} ", colunas[i]));
                    if (colunas[i] != colunas.Last())
                        Procedures.Append(",");
                }
                Procedures.AppendLine(string.Format(" FROM {0}", nomeTabela));
                Procedures.AppendLine(" WHERE ");
                //1 parâmetro para cada coluna
                for (int i = 0; i < colunas.Count; i++)
                {
                    Procedures.AppendLine(string.Format(" {0}=@{1} ", colunas[i], colunas[i]));
                    if (colunas[i] != colunas.Last())
                        Procedures.Append(" AND ");
                }
                Procedures.AppendLine(" END ");
                #endregion

                var arquivo_SELECT = File.Create(caminhoPadrao + string.Format("{0}_SELECT.sql", nomeTabela));
                arquivo = new StreamWriter(arquivo_SELECT);
                arquivo.Write(Procedures.ToString());
                arquivo.Flush();
                arquivo.Dispose();
                Procedures = new StringBuilder();

                #region [ UPDATE ]
                Procedures.AppendLine(" USE ECONOFOOD ");
                Procedures.AppendLine(" GO ");
                Procedures.AppendLine(string.Format(" CREATE PROCEDURE {0}_UPDATE ", nomeTabela));
                Procedures.AppendLine(" ( ");
                //1 parâmetro para cada coluna, menos para a primeira que é PK.
                for (int i = 0; i < colunas.Count; i++)
                {
                    var tipoColuna = colunasTipadas.AsDataView().ToTable().Rows[i].ItemArray[7];
                    var tamanhoColuna = colunasTipadas.AsDataView().ToTable().Rows[i].ItemArray[8];
                    if(tipoColuna.ToString().ToLower() != "varchar")
                        Procedures.AppendLine(string.Format(" @{0} {1}", colunas[i], tipoColuna));
                    else
                        Procedures.AppendLine(string.Format("@{0} {1}({2})", colunas[i], tipoColuna, tamanhoColuna.ToString() == "-1" ? "MAX" : tamanhoColuna));
                    if (colunas[i] != colunas.Last())
                        Procedures.Append(",");
                }
                Procedures.AppendLine(" ) ");
                Procedures.AppendLine(" AS ");
                Procedures.AppendLine(" BEGIN ");
                Procedures.AppendLine(" SET NOCOUNT ON; ");
                Procedures.AppendLine(" ");
                Procedures.AppendLine(string.Format(" UPDATE {0}", nomeTabela));
                Procedures.AppendLine(" SET ");
                //1 parâmetro para cada coluna, menos a PK.
                for (int i = 0; i < colunas.Count; i++)
                {
                    if (colunas[i] == colunas.First())
                        continue;

                    Procedures.AppendLine(string.Format(" {0}=@{1} ", colunas[i], colunas[i]));
                    if (colunas[i] != colunas.Last())
                        Procedures.Append(" , ");
                }
                Procedures.AppendLine(" WHERE ");
                Procedures.AppendLine(string.Format(" {0}=@{1} ", colunas[0], colunas[0]));
                Procedures.AppendLine(" END ");
                #endregion

                var arquivo_UPDATE = File.Create(caminhoPadrao + string.Format("{0}_UPDATE.sql", nomeTabela));
                arquivo = new StreamWriter(arquivo_UPDATE);
                arquivo.Write(Procedures.ToString());
                arquivo.Flush();
                arquivo.Dispose();
                Procedures = new StringBuilder();
            }
            connection.Close();

            MessageBox.Show(@"Procedures criadas em C:\DataBase");
        }
    }
}
