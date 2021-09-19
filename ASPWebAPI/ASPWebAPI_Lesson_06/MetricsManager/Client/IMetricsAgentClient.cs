using MetricsManager.Client.Requests;
using MetricsManager.Client.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client
{
    public interface IMetricsAgentClient
    {
        IEnumerable<CpuMetricsApiResponse> GetCpuMetrics(CpuMetricsApiRequest request);
        IEnumerable<DotNetMetricsApiResponse> GetCpuMetrics(DotNetMetricsApiRequest request);
        IEnumerable<HddMetricsApiResponse> GetCpuMetrics(HddMetricsApiRequest request);
        IEnumerable<NetworkMetricsApiResponse> GetCpuMetrics(NetworkMetricsApiRequest request);
        IEnumerable<RamMetricsApiResponse> GetCpuMetrics(RamMetricsApiRequest request);

        //RamMetricsResponse GetRamMetrics(RamMetricsRequest request);
        //HddMetricsResponse GetHddMetrics(HddMetricsRequest request);
        //DotNetMetricsResponse GetDotNetMetrics(DotNetMetricsRequest request);
        //NetworkMetricsResponse GetNetworkMetrics(NetworkMetricsRequest request);
    }
}
