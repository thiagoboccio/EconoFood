﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EconoFood.Admin.PrecificacaoService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Precificacao", Namespace="http://schemas.datacontract.org/2004/07/EconoFood.Services.DTO")]
    [System.SerializableAttribute()]
    public partial class Precificacao : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DataInicioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdPrecificacaoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdProdutoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PercentualAplicadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal ValorCompraField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal ValorVendaField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DataInicio {
            get {
                return this.DataInicioField;
            }
            set {
                if ((this.DataInicioField.Equals(value) != true)) {
                    this.DataInicioField = value;
                    this.RaisePropertyChanged("DataInicio");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdPrecificacao {
            get {
                return this.IdPrecificacaoField;
            }
            set {
                if ((this.IdPrecificacaoField.Equals(value) != true)) {
                    this.IdPrecificacaoField = value;
                    this.RaisePropertyChanged("IdPrecificacao");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdProduto {
            get {
                return this.IdProdutoField;
            }
            set {
                if ((this.IdProdutoField.Equals(value) != true)) {
                    this.IdProdutoField = value;
                    this.RaisePropertyChanged("IdProduto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal PercentualAplicado {
            get {
                return this.PercentualAplicadoField;
            }
            set {
                if ((this.PercentualAplicadoField.Equals(value) != true)) {
                    this.PercentualAplicadoField = value;
                    this.RaisePropertyChanged("PercentualAplicado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal ValorCompra {
            get {
                return this.ValorCompraField;
            }
            set {
                if ((this.ValorCompraField.Equals(value) != true)) {
                    this.ValorCompraField = value;
                    this.RaisePropertyChanged("ValorCompra");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal ValorVenda {
            get {
                return this.ValorVendaField;
            }
            set {
                if ((this.ValorVendaField.Equals(value) != true)) {
                    this.ValorVendaField = value;
                    this.RaisePropertyChanged("ValorVenda");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PrecificacaoService.IPrecificacao")]
    public interface IPrecificacao {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPrecificacao/Listar", ReplyAction="http://tempuri.org/IPrecificacao/ListarResponse")]
        System.Collections.Generic.List<EconoFood.Admin.PrecificacaoService.Precificacao> Listar();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPrecificacao/Listar", ReplyAction="http://tempuri.org/IPrecificacao/ListarResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<EconoFood.Admin.PrecificacaoService.Precificacao>> ListarAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPrecificacao/PesquisarPorID", ReplyAction="http://tempuri.org/IPrecificacao/PesquisarPorIDResponse")]
        EconoFood.Admin.PrecificacaoService.Precificacao PesquisarPorID(EconoFood.Admin.PrecificacaoService.Precificacao precificacao);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPrecificacao/PesquisarPorID", ReplyAction="http://tempuri.org/IPrecificacao/PesquisarPorIDResponse")]
        System.Threading.Tasks.Task<EconoFood.Admin.PrecificacaoService.Precificacao> PesquisarPorIDAsync(EconoFood.Admin.PrecificacaoService.Precificacao precificacao);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPrecificacao/PesquisarPorProduto", ReplyAction="http://tempuri.org/IPrecificacao/PesquisarPorProdutoResponse")]
        System.Collections.Generic.List<EconoFood.Admin.PrecificacaoService.Precificacao> PesquisarPorProduto(EconoFood.Admin.PrecificacaoService.Precificacao precificacao);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPrecificacao/PesquisarPorProduto", ReplyAction="http://tempuri.org/IPrecificacao/PesquisarPorProdutoResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<EconoFood.Admin.PrecificacaoService.Precificacao>> PesquisarPorProdutoAsync(EconoFood.Admin.PrecificacaoService.Precificacao precificacao);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPrecificacao/Gravar", ReplyAction="http://tempuri.org/IPrecificacao/GravarResponse")]
        int Gravar(EconoFood.Admin.PrecificacaoService.Precificacao precificacao);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPrecificacao/Gravar", ReplyAction="http://tempuri.org/IPrecificacao/GravarResponse")]
        System.Threading.Tasks.Task<int> GravarAsync(EconoFood.Admin.PrecificacaoService.Precificacao precificacao);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPrecificacaoChannel : EconoFood.Admin.PrecificacaoService.IPrecificacao, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PrecificacaoClient : System.ServiceModel.ClientBase<EconoFood.Admin.PrecificacaoService.IPrecificacao>, EconoFood.Admin.PrecificacaoService.IPrecificacao {
        
        public PrecificacaoClient() {
        }
        
        public PrecificacaoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PrecificacaoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PrecificacaoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PrecificacaoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<EconoFood.Admin.PrecificacaoService.Precificacao> Listar() {
            return base.Channel.Listar();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<EconoFood.Admin.PrecificacaoService.Precificacao>> ListarAsync() {
            return base.Channel.ListarAsync();
        }
        
        public EconoFood.Admin.PrecificacaoService.Precificacao PesquisarPorID(EconoFood.Admin.PrecificacaoService.Precificacao precificacao) {
            return base.Channel.PesquisarPorID(precificacao);
        }
        
        public System.Threading.Tasks.Task<EconoFood.Admin.PrecificacaoService.Precificacao> PesquisarPorIDAsync(EconoFood.Admin.PrecificacaoService.Precificacao precificacao) {
            return base.Channel.PesquisarPorIDAsync(precificacao);
        }
        
        public System.Collections.Generic.List<EconoFood.Admin.PrecificacaoService.Precificacao> PesquisarPorProduto(EconoFood.Admin.PrecificacaoService.Precificacao precificacao) {
            return base.Channel.PesquisarPorProduto(precificacao);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<EconoFood.Admin.PrecificacaoService.Precificacao>> PesquisarPorProdutoAsync(EconoFood.Admin.PrecificacaoService.Precificacao precificacao) {
            return base.Channel.PesquisarPorProdutoAsync(precificacao);
        }
        
        public int Gravar(EconoFood.Admin.PrecificacaoService.Precificacao precificacao) {
            return base.Channel.Gravar(precificacao);
        }
        
        public System.Threading.Tasks.Task<int> GravarAsync(EconoFood.Admin.PrecificacaoService.Precificacao precificacao) {
            return base.Channel.GravarAsync(precificacao);
        }
    }
}
