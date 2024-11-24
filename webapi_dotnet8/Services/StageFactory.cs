using Microsoft.Net.Http.Headers;

namespace webapi_dotnet8.Services
{
    public interface IStage
    {
        public Task HandleActionAsync(ReservationAction action, IActionInput? input = null);

    }

    public interface IActionStrategy
    {
        public Task ExcuteAsync();
    }

    public interface IActionInput { }

    public enum ReservationAction
    {
        Start,
        Approve,
        Reject,
        Cancel,
        Recall,
        Reply,
        Assign
    }

    public enum ReservationStage
    {
        Init,
        MgrAssiging,
        SupplierRepling,
        VpApproving,
        Done,
        Cancel
    }

    public class InitStage : IStage
    {
        public async Task HandleActionAsync(ReservationAction action, IActionInput? input = null)
        {
            switch(action)
            {
                case ReservationAction.Start:
                    // 驗證是否為開單人
                    // Buyer 跟 其他 User 會有不同的 nextStage
                    break;
                case ReservationAction.Cancel:
                    break;
                default: 
                    throw new NotImplementedException($"{action} is not implement.");
            }; 
        }
    }

    public class MgrAssigingStage : IStage
    {
        public async Task HandleActionAsync(ReservationAction action, IActionInput? input = null)
        {
            switch (action)
            {
                case ReservationAction.Assign:
                    break;
                case ReservationAction.Reject:
                    break;
                case ReservationAction.Recall:
                    break;
                case ReservationAction.Cancel:
                    break;
                default:
                    throw new NotImplementedException($"{action} is not implement.");
            }
        }
    }

    public class SupplierReplyingStage : IStage
    {
        public async Task HandleActionAsync(ReservationAction action, IActionInput? input = null)
        {
            switch (action)
            {
                case ReservationAction.Reply:
                    break;
                case ReservationAction.Reject:
                    break;
                case ReservationAction.Cancel:
                    break;
                case ReservationAction.Recall:
                    break;
                default:
                    throw new NotImplementedException($"{action} is not implement.");
            }
        }
    }

    public class VpApprovingStage : IStage
    {
        public async Task HandleActionAsync(ReservationAction action, IActionInput? input = null)
        {
            switch (action)
            {
                case ReservationAction.Approve:
                    break;
                case ReservationAction.Reject:
                    break;
                case ReservationAction.Recall:
                    break;
                case ReservationAction.Cancel:
                    break;
                default:
                    throw new NotImplementedException($"{action} is not implement.");
            }
        }
    }

    public class DoneStage : IStage
    {
        public async Task HandleActionAsync(ReservationAction action, IActionInput? input = null)
        {
            switch (action)
            {
                case ReservationAction.Cancel:
                    break;
                default:
                    throw new NotImplementedException($"{action} is not implement.");
            }
        }
    }

    public class StageFactory
    {
        public IStage CreateStage(ReservationStage stage)
        {
            return stage switch
            {
                ReservationStage.Init => new InitStage(),
                ReservationStage.MgrAssiging => new MgrAssigingStage(),
                ReservationStage.SupplierRepling => new SupplierReplyingStage(),
                ReservationStage.VpApproving => new VpApprovingStage(),
                ReservationStage.Done => new DoneStage(),
                _ => throw new NotImplementedException($"{stage} is not implement")
            };
        }
    }

    public class StartAction : IActionStrategy
    {
        public Task ExcuteAsync()
        {
            throw new NotImplementedException();
        }
    }
    public class ReservationService(StageFactory stageFactory)
    {
        public async Task Action(int reservation_id, ReservationAction action, IActionInput input)
        {
            // 透過 repository 去取得當前關卡
            var currentStage = ReservationStage.Init;
            var stage = stageFactory.CreateStage(currentStage);
            await stage.HandleActionAsync(action);
        }

    }

}
