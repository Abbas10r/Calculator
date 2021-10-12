using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CalculatorGrpcService
{
    /// <summary>
    /// ������ ������������
    /// </summary>
    public class CalculatorService : Calculator.CalculatorBase
    {
        private readonly ILogger<CalculatorService> _logger;
        public CalculatorService(ILogger<CalculatorService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<Response> Addition(Numbers nums, ServerCallContext context)
        {
            return Task.FromResult(new Response
            {
                Result = nums.Num1 + nums.Num2
            });
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<Response> Subtraction(Numbers nums, ServerCallContext context)
        {
            return Task.FromResult(new Response
            {
                Result = nums.Num1 - nums.Num2
            });
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<Response> Multiplication(Numbers nums, ServerCallContext context)
        {
            return Task.FromResult(new Response
            {
                Result = nums.Num1 * nums.Num2
            });
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<Response> Division(Numbers nums, ServerCallContext context)
        {
            return Task.FromResult(new Response
            {
                Result = nums.Num1 / nums.Num2
            });
        }
    }
}
