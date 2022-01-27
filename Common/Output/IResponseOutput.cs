using Newtonsoft.Json;

using System.Collections.Generic;

namespace Common.Output
{
    public interface IResponseOutput
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonIgnore]
        bool success { get; }

        /// <summary>
        /// 消息
        /// </summary>
        string msg { get; }

        /// <summary>
        /// 总条数
        /// </summary>
        int total { get; }

    }

    /// <summary>
    /// 响应数据输出泛型接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IResponseOutput<T> : IResponseOutput
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        T data { get; }

    }
}
