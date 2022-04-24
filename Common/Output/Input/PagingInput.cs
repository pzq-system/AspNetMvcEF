namespace Common.Output.Input
{
    public class PagingInput<T>
    {
        /// <summary>
        /// 当前页标
        /// </summary>
        public int page { get; set; } = 1;

        /// <summary>
        /// 每页大小
        /// </summary>
        public int limit { get; set; } = 10;
        
        /// <summary>
        /// 查询条件
        /// </summary>
        public T Filter { get; set; }
    }
}
