﻿using System;
using System.Runtime.InteropServices;
using System.Threading;
using FontSizer.Commands;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace FontSizer
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.guidIncreaseFontSizePackageString)]
    public sealed class VSPackage : AsyncPackage
    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync();

            await IncreaseFontSize.InitializeAsync(this);
            await DecreaseFontSize.InitializeAsync(this);
            await IncreaseEnviornmentFontSize.InitializeAsync(this);
            await DecreaseEnviornmentFontSize.InitializeAsync(this);
        }
    }
}