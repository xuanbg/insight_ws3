﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Test.Service {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Service.IInternal")]
    public interface IInternal {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInternal/Register", ReplyAction="http://tempuri.org/IInternal/RegisterResponse")]
        bool Register(string code, string ln, string pw, string name, string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInternal/SetMemberType", ReplyAction="http://tempuri.org/IInternal/SetMemberTypeResponse")]
        bool SetMemberType(string code, string ln, int type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInternal/SetPassword", ReplyAction="http://tempuri.org/IInternal/SetPasswordResponse")]
        bool SetPassword(string code, string ln, string pw);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInternal/SetUserStatus", ReplyAction="http://tempuri.org/IInternal/SetUserStatusResponse")]
        bool SetUserStatus(string code, string ln, bool validity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInternal/AddBankCard", ReplyAction="http://tempuri.org/IInternal/AddBankCardResponse")]
        bool AddBankCard(string code, string ln, string name, string type, string bank, string number);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInternal/SetBillStatus", ReplyAction="http://tempuri.org/IInternal/SetBillStatusResponse")]
        bool SetBillStatus(string code, int id, string billno, int pay, string paycode, int status);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IInternalChannel : Test.Service.IInternal, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class InternalClient : System.ServiceModel.ClientBase<Test.Service.IInternal>, Test.Service.IInternal {
        
        public InternalClient() {
        }
        
        public InternalClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public InternalClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public InternalClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public InternalClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Register(string code, string ln, string pw, string name, string id) {
            return base.Channel.Register(code, ln, pw, name, id);
        }
        
        public bool SetMemberType(string code, string ln, int type) {
            return base.Channel.SetMemberType(code, ln, type);
        }
        
        public bool SetPassword(string code, string ln, string pw) {
            return base.Channel.SetPassword(code, ln, pw);
        }
        
        public bool SetUserStatus(string code, string ln, bool validity) {
            return base.Channel.SetUserStatus(code, ln, validity);
        }
        
        public bool AddBankCard(string code, string ln, string name, string type, string bank, string number) {
            return base.Channel.AddBankCard(code, ln, name, type, bank, number);
        }
        
        public bool SetBillStatus(string code, int id, string billno, int pay, string paycode, int status) {
            return base.Channel.SetBillStatus(code, id, billno, pay, paycode, status);
        }
    }
}
