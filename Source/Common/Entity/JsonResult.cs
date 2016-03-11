﻿namespace Insight.WS.Server.Common
{
    /// <summary>
    /// Json接口返回值
    /// </summary>
    public class JsonResult
    {
        /// <summary>
        /// 结果
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 错误名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// 初始化为未知错误（500）的错误信息
        /// </summary>
        public JsonResult()
        {
            Code = "500";
            Name = "UnknownError";
            Message = "未知错误";
        }

        #region 接口返回信息

        /// <summary>
        /// 返回接口调用成功（200）的成功信息
        /// </summary>
        /// <param name="data">承载的数据（可选）</param>
        /// <returns>JsonResult</returns>
        public JsonResult Success(string data = null)
        {
            Successful = true;
            Code = "200";
            Name = "OK";
            Message = "接口调用成功";
            Data = data;
            return this;
        }

        /// <summary>
        /// 返回接口调用成功（200）的成功信息
        /// </summary>
        /// <param name="data">承载的数据（可选）</param>
        /// <returns>JsonResult</returns>
        public JsonResult Success(object data)
        {
            Successful = true;
            Code = "200";
            Name = "OK";
            Message = "接口调用成功";
            Data = Util.Serialize(data);
            return this;
        }

        /// <summary>
        /// 返回无可用内容（204）的成功信息
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult NoContent()
        {
            Successful = true;
            Code = "204";
            Name = "NoContent";
            Message = "无可用内容";
            Data = "";
            return this;
        }

        /// <summary>
        /// 返回请求参数错误（400）的错误信息
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult BadRequest()
        {
            Successful = false;
            Code = "400";
            Name = "BadRequest";
            Message = "请求参数错误";
            return this;
        }

        /// <summary>
        /// 返回身份验证失败（401）的错误信息
        /// </summary>
        /// <param name="data">承载的数据（可选）</param>
        /// <returns>JsonResult</returns>
        public JsonResult InvalidAuth(string data = null)
        {
            Successful = false;
            Code = "401";
            Name = "InvalidAuthenticationInfo";
            Message = "提供的身份验证信息不正确";
            Data = data;
            return this;
        }

        /// <summary>
        /// 返回用户未取得授权（403）的错误信息
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult Forbidden()
        {
            Successful = false;
            Code = "403";
            Name = "Forbidden";
            Message = "当前用户未取得授权";
            return this;
        }

        /// <summary>
        /// 返回未找到指定资源（404）的错误信息
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult NotFound()
        {
            Successful = false;
            Code = "404";
            Name = "ResourceNotFound";
            Message = "指定的资源不存在";
            return this;
        }

        /// <summary>
        /// 返回Guid转换失败（406）的错误信息
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult InvalidGuid()
        {
            Successful = false;
            Code = "406";
            Name = "InvalidGUID";
            Message = "非法的GUID";
            return this;
        }

        /// <summary>
        /// 返回更新数据失败（407）的错误信息
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult NotUpdate()
        {
            Successful = false;
            Code = "407";
            Name = "DataNotUpdate";
            Message = "未更新任何数据";
            return this;
        }

        /// <summary>
        /// 返回短信验证码错误（410）的错误信息
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult SMSCodeError()
        {
            Successful = false;
            Code = "410";
            Name = "SMSCodeError";
            Message = "短信验证码错误";
            return this;
        }

        /// <summary>
        /// 返回未知的验证码类型（411）的错误信息
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult UnknownSmsType()
        {
            Successful = false;
            Code = "411";
            Name = "UnknownSmsType";
            Message = "未知的验证码类型";
            return this;
        }

        /// <summary>
        /// 返回请求发送验证码时间间隔过短（412）的错误信息
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult TimeTooShort()
        {
            Successful = false;
            Code = "412";
            Name = "TimeIntervalTooShort";
            Message = "请求发送验证码时间间隔过短，请稍后再试";
            return this;
        }

        /// <summary>
        /// 返回数据库操作失败（501）的错误信息
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult DataBaseError()
        {
            Successful = false;
            Code = "501";
            Name = "DataBaseError";
            Message = "写入数据失败";
            return this;
        }

        /// <summary>
        /// 返回数据已存在（502）的错误信息
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult DataAlreadyExists()
        {
            Successful = false;
            Code = "502";
            Name = "DataAlreadyExists";
            Message = "数据已存在";
            return this;
        }

        /// <summary>
        /// 返回服务不可用（503）的错误信息
        /// </summary>
        /// <returns>JsonResult</returns>
        public JsonResult ServiceUnavailable()
        {
            Successful = false;
            Code = "503";
            Name = "ServiceUnavailable";
            Message = "当前服务不可用";
            return this;
        }

        #endregion

    }
}