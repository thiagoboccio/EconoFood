﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EconoFood.ProdutoService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Produto", Namespace="http://schemas.datacontract.org/2004/07/EconoFood.Services.DTO")]
    [System.SerializableAttribute()]
    public partial class Produto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdProdutoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StatusField;
        
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
        public string Nome {
            get {
                return this.NomeField;
            }
            set {
                if ((object.ReferenceEquals(this.NomeField, value) != true)) {
                    this.NomeField = value;
                    this.RaisePropertyChanged("Nome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProdutoService.IProduto")]
    public interface IProduto {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProduto/Listar", ReplyAction="http://tempuri.org/IProduto/ListarResponse")]
        EconoFood.ProdutoService.ListarResponse Listar(EconoFood.ProdutoService.ListarRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProduto/Listar", ReplyAction="http://tempuri.org/IProduto/ListarResponse")]
        System.Threading.Tasks.Task<EconoFood.ProdutoService.ListarResponse> ListarAsync(EconoFood.ProdutoService.ListarRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProduto/PesquisarPorNome", ReplyAction="http://tempuri.org/IProduto/PesquisarPorNomeResponse")]
        EconoFood.ProdutoService.PesquisarPorNomeResponse PesquisarPorNome(EconoFood.ProdutoService.PesquisarPorNomeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProduto/PesquisarPorNome", ReplyAction="http://tempuri.org/IProduto/PesquisarPorNomeResponse")]
        System.Threading.Tasks.Task<EconoFood.ProdutoService.PesquisarPorNomeResponse> PesquisarPorNomeAsync(EconoFood.ProdutoService.PesquisarPorNomeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProduto/PesquisarPorID", ReplyAction="http://tempuri.org/IProduto/PesquisarPorIDResponse")]
        EconoFood.ProdutoService.PesquisarPorIDResponse PesquisarPorID(EconoFood.ProdutoService.PesquisarPorIDRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProduto/PesquisarPorID", ReplyAction="http://tempuri.org/IProduto/PesquisarPorIDResponse")]
        System.Threading.Tasks.Task<EconoFood.ProdutoService.PesquisarPorIDResponse> PesquisarPorIDAsync(EconoFood.ProdutoService.PesquisarPorIDRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Listar", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ListarRequest {
        
        public ListarRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ListarResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ListarResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.Collections.Generic.List<EconoFood.ProdutoService.Produto> ListarResult;
        
        public ListarResponse() {
        }
        
        public ListarResponse(System.Collections.Generic.List<EconoFood.ProdutoService.Produto> ListarResult) {
            this.ListarResult = ListarResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PesquisarPorNome", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class PesquisarPorNomeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string nomeProduto;
        
        public PesquisarPorNomeRequest() {
        }
        
        public PesquisarPorNomeRequest(string nomeProduto) {
            this.nomeProduto = nomeProduto;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PesquisarPorNomeResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class PesquisarPorNomeResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.Collections.Generic.List<EconoFood.ProdutoService.Produto> PesquisarPorNomeResult;
        
        public PesquisarPorNomeResponse() {
        }
        
        public PesquisarPorNomeResponse(System.Collections.Generic.List<EconoFood.ProdutoService.Produto> PesquisarPorNomeResult) {
            this.PesquisarPorNomeResult = PesquisarPorNomeResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PesquisarPorID", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class PesquisarPorIDRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int idProduto;
        
        public PesquisarPorIDRequest() {
        }
        
        public PesquisarPorIDRequest(int idProduto) {
            this.idProduto = idProduto;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PesquisarPorIDResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class PesquisarPorIDResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.Collections.Generic.List<EconoFood.ProdutoService.Produto> PesquisarPorIDResult;
        
        public PesquisarPorIDResponse() {
        }
        
        public PesquisarPorIDResponse(System.Collections.Generic.List<EconoFood.ProdutoService.Produto> PesquisarPorIDResult) {
            this.PesquisarPorIDResult = PesquisarPorIDResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProdutoChannel : EconoFood.ProdutoService.IProduto, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProdutoClient : System.ServiceModel.ClientBase<EconoFood.ProdutoService.IProduto>, EconoFood.ProdutoService.IProduto {
        
        public ProdutoClient() {
        }
        
        public ProdutoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProdutoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProdutoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProdutoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public EconoFood.ProdutoService.ListarResponse Listar(EconoFood.ProdutoService.ListarRequest request) {
            return base.Channel.Listar(request);
        }
        
        public System.Threading.Tasks.Task<EconoFood.ProdutoService.ListarResponse> ListarAsync(EconoFood.ProdutoService.ListarRequest request) {
            return base.Channel.ListarAsync(request);
        }
        
        public EconoFood.ProdutoService.PesquisarPorNomeResponse PesquisarPorNome(EconoFood.ProdutoService.PesquisarPorNomeRequest request) {
            return base.Channel.PesquisarPorNome(request);
        }
        
        public System.Threading.Tasks.Task<EconoFood.ProdutoService.PesquisarPorNomeResponse> PesquisarPorNomeAsync(EconoFood.ProdutoService.PesquisarPorNomeRequest request) {
            return base.Channel.PesquisarPorNomeAsync(request);
        }
        
        public EconoFood.ProdutoService.PesquisarPorIDResponse PesquisarPorID(EconoFood.ProdutoService.PesquisarPorIDRequest request) {
            return base.Channel.PesquisarPorID(request);
        }
        
        public System.Threading.Tasks.Task<EconoFood.ProdutoService.PesquisarPorIDResponse> PesquisarPorIDAsync(EconoFood.ProdutoService.PesquisarPorIDRequest request) {
            return base.Channel.PesquisarPorIDAsync(request);
        }
    }
}
