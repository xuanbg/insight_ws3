﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System.Web.Script.Serialization;

namespace Insight.WS.Server.Common.Service {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Session", Namespace="http://schemas.datacontract.org/2004/07/Insight.WS.Verify")]
    [System.SerializableAttribute()]
    public partial class Session : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BaseAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ClientTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.Guid> DeptIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DeptNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FailureCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LastConnectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LoginNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Insight.WS.Server.Common.Service.LoginResult LoginResultField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MachineIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool OnlineStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OpenIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SignatureField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid UserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ValidityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int VersionField;
        
        [ScriptIgnore]
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
        public string BaseAddress {
            get {
                return this.BaseAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.BaseAddressField, value) != true)) {
                    this.BaseAddressField = value;
                    this.RaisePropertyChanged("BaseAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ClientType {
            get {
                return this.ClientTypeField;
            }
            set {
                if ((this.ClientTypeField.Equals(value) != true)) {
                    this.ClientTypeField = value;
                    this.RaisePropertyChanged("ClientType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.Guid> DeptId {
            get {
                return this.DeptIdField;
            }
            set {
                if ((this.DeptIdField.Equals(value) != true)) {
                    this.DeptIdField = value;
                    this.RaisePropertyChanged("DeptId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DeptName {
            get {
                return this.DeptNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DeptNameField, value) != true)) {
                    this.DeptNameField = value;
                    this.RaisePropertyChanged("DeptName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FailureCount {
            get {
                return this.FailureCountField;
            }
            set {
                if ((this.FailureCountField.Equals(value) != true)) {
                    this.FailureCountField = value;
                    this.RaisePropertyChanged("FailureCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID {
            get {
                return this.IDField;
            }
            set {
                if ((this.IDField.Equals(value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LastConnect {
            get {
                return this.LastConnectField;
            }
            set {
                if ((this.LastConnectField.Equals(value) != true)) {
                    this.LastConnectField = value;
                    this.RaisePropertyChanged("LastConnect");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LoginName {
            get {
                return this.LoginNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginNameField, value) != true)) {
                    this.LoginNameField = value;
                    this.RaisePropertyChanged("LoginName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Insight.WS.Server.Common.Service.LoginResult LoginResult {
            get {
                return this.LoginResultField;
            }
            set {
                if ((this.LoginResultField.Equals(value) != true)) {
                    this.LoginResultField = value;
                    this.RaisePropertyChanged("LoginResult");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MachineId {
            get {
                return this.MachineIdField;
            }
            set {
                if ((object.ReferenceEquals(this.MachineIdField, value) != true)) {
                    this.MachineIdField = value;
                    this.RaisePropertyChanged("MachineId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool OnlineStatus {
            get {
                return this.OnlineStatusField;
            }
            set {
                if ((this.OnlineStatusField.Equals(value) != true)) {
                    this.OnlineStatusField = value;
                    this.RaisePropertyChanged("OnlineStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OpenId {
            get {
                return this.OpenIdField;
            }
            set {
                if ((object.ReferenceEquals(this.OpenIdField, value) != true)) {
                    this.OpenIdField = value;
                    this.RaisePropertyChanged("OpenId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Signature {
            get {
                return this.SignatureField;
            }
            set {
                if ((object.ReferenceEquals(this.SignatureField, value) != true)) {
                    this.SignatureField = value;
                    this.RaisePropertyChanged("Signature");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserType {
            get {
                return this.UserTypeField;
            }
            set {
                if ((this.UserTypeField.Equals(value) != true)) {
                    this.UserTypeField = value;
                    this.RaisePropertyChanged("UserType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Validity {
            get {
                return this.ValidityField;
            }
            set {
                if ((this.ValidityField.Equals(value) != true)) {
                    this.ValidityField = value;
                    this.RaisePropertyChanged("Validity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Version {
            get {
                return this.VersionField;
            }
            set {
                if ((this.VersionField.Equals(value) != true)) {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LoginResult", Namespace="http://schemas.datacontract.org/2004/07/Insight.WS.Verify")]
    public enum LoginResult : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Success = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Multiple = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Online = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Failure = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Banned = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NotExist = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Unauthorized = 6,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Service.Interface")]
    public interface Interface {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Interface/GetCode", ReplyAction="http://tempuri.org/Interface/GetCodeResponse")]
        string GetCode(int type, string mobile, int time);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Interface/VerifyCode", ReplyAction="http://tempuri.org/Interface/VerifyCodeResponse")]
        bool VerifyCode(string mobile, string code, int type, bool remove);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Interface/UserLogin", ReplyAction="http://tempuri.org/Interface/UserLoginResponse")]
        Insight.WS.Server.Common.Service.Session UserLogin(Insight.WS.Server.Common.Service.Session obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Interface/GetSessions", ReplyAction="http://tempuri.org/Interface/GetSessionsResponse")]
        System.Collections.Generic.List<Insight.WS.Server.Common.Service.Session> GetSessions(Insight.WS.Server.Common.Service.Session obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Interface/UpdateSignature", ReplyAction="http://tempuri.org/Interface/UpdateSignatureResponse")]
        bool UpdateSignature(Insight.WS.Server.Common.Service.Session obj, System.Guid id, string pw);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Interface/UpdateUserInfo", ReplyAction="http://tempuri.org/Interface/UpdateUserInfoResponse")]
        bool UpdateUserInfo(Insight.WS.Server.Common.Service.Session obj, System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Interface/SetUserOffline", ReplyAction="http://tempuri.org/Interface/SetUserOfflineResponse")]
        bool SetUserOffline(Insight.WS.Server.Common.Service.Session obj, System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Interface/SetUserStatus", ReplyAction="http://tempuri.org/Interface/SetUserStatusResponse")]
        bool SetUserStatus(Insight.WS.Server.Common.Service.Session obj, System.Guid uid, bool validity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Interface/Authorization", ReplyAction="http://tempuri.org/Interface/AuthorizationResponse")]
        bool Authorization(Insight.WS.Server.Common.Service.Session obj, string action);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Interface/Verification", ReplyAction="http://tempuri.org/Interface/VerificationResponse")]
        Insight.WS.Server.Common.Service.Session Verification(Insight.WS.Server.Common.Service.Session obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Interface/SimpleVerification", ReplyAction="http://tempuri.org/Interface/SimpleVerificationResponse")]
        bool SimpleVerification(Insight.WS.Server.Common.Service.Session obj);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface InterfaceChannel : Insight.WS.Server.Common.Service.Interface, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class InterfaceClient : System.ServiceModel.ClientBase<Insight.WS.Server.Common.Service.Interface>, Insight.WS.Server.Common.Service.Interface {
        
        public InterfaceClient() {
        }
        
        public InterfaceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public InterfaceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public InterfaceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public InterfaceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetCode(int type, string mobile, int time) {
            return base.Channel.GetCode(type, mobile, time);
        }
        
        public bool VerifyCode(string mobile, string code, int type, bool remove) {
            return base.Channel.VerifyCode(mobile, code, type, remove);
        }
        
        public Insight.WS.Server.Common.Service.Session UserLogin(Insight.WS.Server.Common.Service.Session obj) {
            return base.Channel.UserLogin(obj);
        }
        
        public System.Collections.Generic.List<Insight.WS.Server.Common.Service.Session> GetSessions(Insight.WS.Server.Common.Service.Session obj) {
            return base.Channel.GetSessions(obj);
        }
        
        public bool UpdateSignature(Insight.WS.Server.Common.Service.Session obj, System.Guid id, string pw) {
            return base.Channel.UpdateSignature(obj, id, pw);
        }
        
        public bool UpdateUserInfo(Insight.WS.Server.Common.Service.Session obj, System.Guid id) {
            return base.Channel.UpdateUserInfo(obj, id);
        }
        
        public bool SetUserOffline(Insight.WS.Server.Common.Service.Session obj, System.Guid id) {
            return base.Channel.SetUserOffline(obj, id);
        }
        
        public bool SetUserStatus(Insight.WS.Server.Common.Service.Session obj, System.Guid uid, bool validity) {
            return base.Channel.SetUserStatus(obj, uid, validity);
        }
        
        public bool Authorization(Insight.WS.Server.Common.Service.Session obj, string action) {
            return base.Channel.Authorization(obj, action);
        }
        
        public Insight.WS.Server.Common.Service.Session Verification(Insight.WS.Server.Common.Service.Session obj) {
            return base.Channel.Verification(obj);
        }
        
        public bool SimpleVerification(Insight.WS.Server.Common.Service.Session obj) {
            return base.Channel.SimpleVerification(obj);
        }
    }
}
