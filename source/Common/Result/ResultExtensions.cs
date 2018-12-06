﻿namespace KadGen.Common.ResultExtensions
{
    public static class ResultExtensions
    {
        public static DataResult<TData> CreateSuccessResult<TData>(this TData data) 
            => new DataResult<TData>(data, null, null);
    }
}
