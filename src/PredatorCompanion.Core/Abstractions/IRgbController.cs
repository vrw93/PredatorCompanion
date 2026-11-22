using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PredatorCompanion.Core.Models;

namespace PredatorCompanion.Core.Abstractions;

public interface IRgbController
{
    Task ConnectAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<RgbDevice>> GetDevicesAsync(
        CancellationToken cancellationToken = default);

    Task ApplyAsync(
        IReadOnlyList<RgbLedUpdate> updates,
        CancellationToken cancellationToken = default);
}