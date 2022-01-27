using Newtonsoft.Json;

using System.Collections.Generic;

namespace Common.Output
{
    public class ResponseOutput<T> : IResponseOutput<T>
    {
        /// <summary>
        /// 是否成功标记
        /// </summary>
        [JsonIgnore]
        public bool success { get; private set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public string code => success ? "0" : "0020";

        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; private set; }

        /// <summary>
        /// 总条数
        /// </summary>
        public int total { get; private set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T data { get; private set; }

        /// <summary>
        /// 分页返回成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="msg">消息</param>
        public ResponseOutput<T> Ok(T data, int total = 0, string msg = null)
        {
            success = true;
            this.data = data;
            this.total = total;
            this.msg = msg;
            return this;
        }



        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public ResponseOutput<T> NotOk(string msg = null)
        {
            success = false;
            this.msg = msg;
            return this;
        }
    }

    /// <summary>
    /// 响应数据静态输出
    /// </summary>
    public static partial class ResponseOutput
    {
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static IResponseOutput Ok<T>(T data = default(T), int total = 0, string msg = null)
        {
            return new ResponseOutput<T>().Ok(data, total, msg);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public static IResponseOutput Ok()
        {
            return Ok<string>();
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static IResponseOutput NotOk<T>(string msg = null)
        {
            return new ResponseOutput<T>().NotOk(msg);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static IResponseOutput NotOk(string msg = null)
        {
            return new ResponseOutput<string>().NotOk(msg);
        }

        /// <summary>
        /// 根据布尔值返回结果
        /// </summary>
        /// <param name="success"></param>
        /// <returns></returns>
        //public static IResponseOutput Result<T>(bool success)
        //{
        //    return success ? Ok<T>() : NotOk<T>();
        //}

        ///// <summary>
        ///// 根据布尔值返回结果
        ///// </summary>
        ///// <param name="success"></param>
        ///// <returns></returns>
        //public static IResponseOutput Result(bool success)
        //{
        //    return success ? Ok() : NotOk();
        //}
    }
}
