using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.MS.LifecycleStates
{
    public enum OrderState
    {
        PreValidation,
        Validated,
        Open,
        PendingFullFillment,
        PendingShipping,
        Shipped,
        DeliveryConfirmed,
        ReturnPending,
        ReturnArrived,
        ReturnPendingAcceptance,
        ReturnAccepted,
        ReturnRejected,
        ReturnRefunded
    }
}
