﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34209
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insight.WS.Client.MainApp.Service {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UpdateFile", Namespace="http://schemas.datacontract.org/2004/07/Insight.WS.Server.Common")]
    [System.SerializableAttribute()]
    internal partial class UpdateFile : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FullPathField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PathField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VersionField;
        
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
        internal string FullPath {
            get {
                return this.FullPathField;
            }
            set {
                if ((object.ReferenceEquals(this.FullPathField, value) != true)) {
                    this.FullPathField = value;
                    this.RaisePropertyChanged("FullPath");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string Path {
            get {
                return this.PathField;
            }
            set {
                if ((object.ReferenceEquals(this.PathField, value) != true)) {
                    this.PathField = value;
                    this.RaisePropertyChanged("Path");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        internal string Version {
            get {
                return this.VersionField;
            }
            set {
                if ((object.ReferenceEquals(this.VersionField, value) != true)) {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            var propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Service.ILogin")]
    internal interface ILogin {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogin/GetDeptList", ReplyAction="http://tempuri.org/ILogin/GetDeptListResponse")]
        System.Data.DataTable GetDeptList(string loginName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogin/UserLogin", ReplyAction="http://tempuri.org/ILogin/UserLoginResponse")]
        Insight.WS.Client.Common.Service.Session UserLogin(Insight.WS.Client.Common.Service.Session us);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogin/GetServerList", ReplyAction="http://tempuri.org/ILogin/GetServerListResponse")]
        System.Collections.Generic.List<Insight.WS.Client.MainApp.Service.UpdateFile> GetServerList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogin/GetFile", ReplyAction="http://tempuri.org/ILogin/GetFileResponse")]
        byte[] GetFile(Insight.WS.Client.MainApp.Service.UpdateFile file);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal interface ILoginChannel : Insight.WS.Client.MainApp.Service.ILogin, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    internal partial class LoginClient : System.ServiceModel.ClientBase<Insight.WS.Client.MainApp.Service.ILogin>, Insight.WS.Client.MainApp.Service.ILogin {
        
        public LoginClient() {
        }
        
        public LoginClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LoginClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataTable GetDeptList(string loginName) {
            return base.Channel.GetDeptList(loginName);
        }
        
        public Insight.WS.Client.Common.Service.Session UserLogin(Insight.WS.Client.Common.Service.Session us) {
            return base.Channel.UserLogin(us);
        }
        
        public System.Collections.Generic.List<Insight.WS.Client.MainApp.Service.UpdateFile> GetServerList() {
            return base.Channel.GetServerList();
        }
        
        public byte[] GetFile(Insight.WS.Client.MainApp.Service.UpdateFile file) {
            return base.Channel.GetFile(file);
        }
    }
}
