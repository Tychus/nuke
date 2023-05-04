// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Helm/Helm.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.Helm;

/// <summary>
///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[PathToolRequirement(HelmPathExecutable)]
public partial class HelmTasks
    : IRequirePathTool
{
    public const string HelmPathExecutable = "helm";
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public static string HelmPath =>
        ToolPathResolver.TryGetEnvironmentExecutable("HELM_EXE") ??
        ToolPathResolver.GetPathExecutable("helm");
    public static Action<OutputType, string> HelmLogger { get; set; } = ProcessTasks.DefaultLogger;
    public static Action<ToolSettings, IProcess> HelmExitHandler { get; set; } = ProcessTasks.DefaultExitHandler;
    /// <summary>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    public static IReadOnlyCollection<Output> Helm(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Action<IProcess> exitHandler = null)
    {
        using var process = ProcessTasks.StartProcess(HelmPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger ?? HelmLogger);
        (exitHandler ?? (p => HelmExitHandler.Invoke(null, p))).Invoke(process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Generate autocompletions script for Helm for the specified shell (bash or zsh). This command can generate shell autocompletions. e.g. 	$ helm completion bash Can be sourced as such 	$ source &lt;(helm completion bash).</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;shell&gt;</c> via <see cref="HelmCompletionSettings.Shell"/></li>
    ///     <li><c>--help</c> via <see cref="HelmCompletionSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmCompletion(HelmCompletionSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmCompletionSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Generate autocompletions script for Helm for the specified shell (bash or zsh). This command can generate shell autocompletions. e.g. 	$ helm completion bash Can be sourced as such 	$ source &lt;(helm completion bash).</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;shell&gt;</c> via <see cref="HelmCompletionSettings.Shell"/></li>
    ///     <li><c>--help</c> via <see cref="HelmCompletionSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmCompletion(Configure<HelmCompletionSettings> configurator)
    {
        return HelmCompletion(configurator(new HelmCompletionSettings()));
    }
    /// <summary>
    ///   <p>Generate autocompletions script for Helm for the specified shell (bash or zsh). This command can generate shell autocompletions. e.g. 	$ helm completion bash Can be sourced as such 	$ source &lt;(helm completion bash).</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;shell&gt;</c> via <see cref="HelmCompletionSettings.Shell"/></li>
    ///     <li><c>--help</c> via <see cref="HelmCompletionSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmCompletionSettings Settings, IReadOnlyCollection<Output> Output)> HelmCompletion(CombinatorialConfigure<HelmCompletionSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmCompletion, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command creates a chart directory along with the common files and directories used in a chart. For example, 'helm create foo' will create a directory structure that looks something like this: 	foo/ 	  | 	  |- .helmignore        # Contains patterns to ignore when packaging Helm charts. 	  | 	  |- Chart.yaml         # Information about your chart 	  | 	  |- values.yaml        # The default values for your templates 	  | 	  |- charts/            # Charts that this chart depends on 	  | 	  |- templates/         # The template files 	  | 	  |- templates/tests/   # The test files 'helm create' takes a path for an argument. If directories in the given path do not exist, Helm will attempt to create them as it goes. If the given destination exists and there are files in that directory, conflicting files will be overwritten, but other files will be left alone.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;name&gt;</c> via <see cref="HelmCreateSettings.Name"/></li>
    ///     <li><c>--help</c> via <see cref="HelmCreateSettings.Help"/></li>
    ///     <li><c>--starter</c> via <see cref="HelmCreateSettings.Starter"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmCreate(HelmCreateSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmCreateSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command creates a chart directory along with the common files and directories used in a chart. For example, 'helm create foo' will create a directory structure that looks something like this: 	foo/ 	  | 	  |- .helmignore        # Contains patterns to ignore when packaging Helm charts. 	  | 	  |- Chart.yaml         # Information about your chart 	  | 	  |- values.yaml        # The default values for your templates 	  | 	  |- charts/            # Charts that this chart depends on 	  | 	  |- templates/         # The template files 	  | 	  |- templates/tests/   # The test files 'helm create' takes a path for an argument. If directories in the given path do not exist, Helm will attempt to create them as it goes. If the given destination exists and there are files in that directory, conflicting files will be overwritten, but other files will be left alone.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;name&gt;</c> via <see cref="HelmCreateSettings.Name"/></li>
    ///     <li><c>--help</c> via <see cref="HelmCreateSettings.Help"/></li>
    ///     <li><c>--starter</c> via <see cref="HelmCreateSettings.Starter"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmCreate(Configure<HelmCreateSettings> configurator)
    {
        return HelmCreate(configurator(new HelmCreateSettings()));
    }
    /// <summary>
    ///   <p>This command creates a chart directory along with the common files and directories used in a chart. For example, 'helm create foo' will create a directory structure that looks something like this: 	foo/ 	  | 	  |- .helmignore        # Contains patterns to ignore when packaging Helm charts. 	  | 	  |- Chart.yaml         # Information about your chart 	  | 	  |- values.yaml        # The default values for your templates 	  | 	  |- charts/            # Charts that this chart depends on 	  | 	  |- templates/         # The template files 	  | 	  |- templates/tests/   # The test files 'helm create' takes a path for an argument. If directories in the given path do not exist, Helm will attempt to create them as it goes. If the given destination exists and there are files in that directory, conflicting files will be overwritten, but other files will be left alone.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;name&gt;</c> via <see cref="HelmCreateSettings.Name"/></li>
    ///     <li><c>--help</c> via <see cref="HelmCreateSettings.Help"/></li>
    ///     <li><c>--starter</c> via <see cref="HelmCreateSettings.Starter"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmCreateSettings Settings, IReadOnlyCollection<Output> Output)> HelmCreate(CombinatorialConfigure<HelmCreateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmCreate, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command takes a release name, and then deletes the release from Kubernetes. It removes all of the resources associated with the last release of the chart. Use the '--dry-run' flag to see which releases will be deleted without actually deleting them.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseNames&gt;</c> via <see cref="HelmDeleteSettings.ReleaseNames"/></li>
    ///     <li><c>--description</c> via <see cref="HelmDeleteSettings.Description"/></li>
    ///     <li><c>--dry-run</c> via <see cref="HelmDeleteSettings.DryRun"/></li>
    ///     <li><c>--help</c> via <see cref="HelmDeleteSettings.Help"/></li>
    ///     <li><c>--no-hooks</c> via <see cref="HelmDeleteSettings.NoHooks"/></li>
    ///     <li><c>--purge</c> via <see cref="HelmDeleteSettings.Purge"/></li>
    ///     <li><c>--timeout</c> via <see cref="HelmDeleteSettings.Timeout"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmDeleteSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmDeleteSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmDeleteSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmDeleteSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmDeleteSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmDeleteSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmDelete(HelmDeleteSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmDeleteSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command takes a release name, and then deletes the release from Kubernetes. It removes all of the resources associated with the last release of the chart. Use the '--dry-run' flag to see which releases will be deleted without actually deleting them.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseNames&gt;</c> via <see cref="HelmDeleteSettings.ReleaseNames"/></li>
    ///     <li><c>--description</c> via <see cref="HelmDeleteSettings.Description"/></li>
    ///     <li><c>--dry-run</c> via <see cref="HelmDeleteSettings.DryRun"/></li>
    ///     <li><c>--help</c> via <see cref="HelmDeleteSettings.Help"/></li>
    ///     <li><c>--no-hooks</c> via <see cref="HelmDeleteSettings.NoHooks"/></li>
    ///     <li><c>--purge</c> via <see cref="HelmDeleteSettings.Purge"/></li>
    ///     <li><c>--timeout</c> via <see cref="HelmDeleteSettings.Timeout"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmDeleteSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmDeleteSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmDeleteSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmDeleteSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmDeleteSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmDeleteSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmDelete(Configure<HelmDeleteSettings> configurator)
    {
        return HelmDelete(configurator(new HelmDeleteSettings()));
    }
    /// <summary>
    ///   <p>This command takes a release name, and then deletes the release from Kubernetes. It removes all of the resources associated with the last release of the chart. Use the '--dry-run' flag to see which releases will be deleted without actually deleting them.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseNames&gt;</c> via <see cref="HelmDeleteSettings.ReleaseNames"/></li>
    ///     <li><c>--description</c> via <see cref="HelmDeleteSettings.Description"/></li>
    ///     <li><c>--dry-run</c> via <see cref="HelmDeleteSettings.DryRun"/></li>
    ///     <li><c>--help</c> via <see cref="HelmDeleteSettings.Help"/></li>
    ///     <li><c>--no-hooks</c> via <see cref="HelmDeleteSettings.NoHooks"/></li>
    ///     <li><c>--purge</c> via <see cref="HelmDeleteSettings.Purge"/></li>
    ///     <li><c>--timeout</c> via <see cref="HelmDeleteSettings.Timeout"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmDeleteSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmDeleteSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmDeleteSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmDeleteSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmDeleteSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmDeleteSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmDeleteSettings Settings, IReadOnlyCollection<Output> Output)> HelmDelete(CombinatorialConfigure<HelmDeleteSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmDelete, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>Build out the charts/ directory from the requirements.lock file. Build is used to reconstruct a chart's dependencies to the state specified in the lock file. This will not re-negotiate dependencies, as 'helm dependency update' does. If no lock file is found, 'helm dependency build' will mirror the behavior of 'helm dependency update'.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyBuildSettings.Chart"/></li>
    ///     <li><c>--help</c> via <see cref="HelmDependencyBuildSettings.Help"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmDependencyBuildSettings.Keyring"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmDependencyBuildSettings.Verify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmDependencyBuild(HelmDependencyBuildSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmDependencyBuildSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Build out the charts/ directory from the requirements.lock file. Build is used to reconstruct a chart's dependencies to the state specified in the lock file. This will not re-negotiate dependencies, as 'helm dependency update' does. If no lock file is found, 'helm dependency build' will mirror the behavior of 'helm dependency update'.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyBuildSettings.Chart"/></li>
    ///     <li><c>--help</c> via <see cref="HelmDependencyBuildSettings.Help"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmDependencyBuildSettings.Keyring"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmDependencyBuildSettings.Verify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmDependencyBuild(Configure<HelmDependencyBuildSettings> configurator)
    {
        return HelmDependencyBuild(configurator(new HelmDependencyBuildSettings()));
    }
    /// <summary>
    ///   <p>Build out the charts/ directory from the requirements.lock file. Build is used to reconstruct a chart's dependencies to the state specified in the lock file. This will not re-negotiate dependencies, as 'helm dependency update' does. If no lock file is found, 'helm dependency build' will mirror the behavior of 'helm dependency update'.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyBuildSettings.Chart"/></li>
    ///     <li><c>--help</c> via <see cref="HelmDependencyBuildSettings.Help"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmDependencyBuildSettings.Keyring"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmDependencyBuildSettings.Verify"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmDependencyBuildSettings Settings, IReadOnlyCollection<Output> Output)> HelmDependencyBuild(CombinatorialConfigure<HelmDependencyBuildSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmDependencyBuild, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>List all of the dependencies declared in a chart. This can take chart archives and chart directories as input. It will not alter the contents of a chart. This will produce an error if the chart cannot be loaded. It will emit a warning if it cannot find a requirements.yaml.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyListSettings.Chart"/></li>
    ///     <li><c>--help</c> via <see cref="HelmDependencyListSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmDependencyList(HelmDependencyListSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmDependencyListSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>List all of the dependencies declared in a chart. This can take chart archives and chart directories as input. It will not alter the contents of a chart. This will produce an error if the chart cannot be loaded. It will emit a warning if it cannot find a requirements.yaml.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyListSettings.Chart"/></li>
    ///     <li><c>--help</c> via <see cref="HelmDependencyListSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmDependencyList(Configure<HelmDependencyListSettings> configurator)
    {
        return HelmDependencyList(configurator(new HelmDependencyListSettings()));
    }
    /// <summary>
    ///   <p>List all of the dependencies declared in a chart. This can take chart archives and chart directories as input. It will not alter the contents of a chart. This will produce an error if the chart cannot be loaded. It will emit a warning if it cannot find a requirements.yaml.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyListSettings.Chart"/></li>
    ///     <li><c>--help</c> via <see cref="HelmDependencyListSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmDependencyListSettings Settings, IReadOnlyCollection<Output> Output)> HelmDependencyList(CombinatorialConfigure<HelmDependencyListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmDependencyList, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>Update the on-disk dependencies to mirror the requirements.yaml file. This command verifies that the required charts, as expressed in 'requirements.yaml', are present in 'charts/' and are at an acceptable version. It will pull down the latest charts that satisfy the dependencies, and clean up old dependencies. On successful update, this will generate a lock file that can be used to rebuild the requirements to an exact version. Dependencies are not required to be represented in 'requirements.yaml'. For that reason, an update command will not remove charts unless they are (a) present in the requirements.yaml file, but (b) at the wrong version.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyUpdateSettings.Chart"/></li>
    ///     <li><c>--help</c> via <see cref="HelmDependencyUpdateSettings.Help"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmDependencyUpdateSettings.Keyring"/></li>
    ///     <li><c>--skip-refresh</c> via <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmDependencyUpdateSettings.Verify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmDependencyUpdate(HelmDependencyUpdateSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmDependencyUpdateSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Update the on-disk dependencies to mirror the requirements.yaml file. This command verifies that the required charts, as expressed in 'requirements.yaml', are present in 'charts/' and are at an acceptable version. It will pull down the latest charts that satisfy the dependencies, and clean up old dependencies. On successful update, this will generate a lock file that can be used to rebuild the requirements to an exact version. Dependencies are not required to be represented in 'requirements.yaml'. For that reason, an update command will not remove charts unless they are (a) present in the requirements.yaml file, but (b) at the wrong version.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyUpdateSettings.Chart"/></li>
    ///     <li><c>--help</c> via <see cref="HelmDependencyUpdateSettings.Help"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmDependencyUpdateSettings.Keyring"/></li>
    ///     <li><c>--skip-refresh</c> via <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmDependencyUpdateSettings.Verify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmDependencyUpdate(Configure<HelmDependencyUpdateSettings> configurator)
    {
        return HelmDependencyUpdate(configurator(new HelmDependencyUpdateSettings()));
    }
    /// <summary>
    ///   <p>Update the on-disk dependencies to mirror the requirements.yaml file. This command verifies that the required charts, as expressed in 'requirements.yaml', are present in 'charts/' and are at an acceptable version. It will pull down the latest charts that satisfy the dependencies, and clean up old dependencies. On successful update, this will generate a lock file that can be used to rebuild the requirements to an exact version. Dependencies are not required to be represented in 'requirements.yaml'. For that reason, an update command will not remove charts unless they are (a) present in the requirements.yaml file, but (b) at the wrong version.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyUpdateSettings.Chart"/></li>
    ///     <li><c>--help</c> via <see cref="HelmDependencyUpdateSettings.Help"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmDependencyUpdateSettings.Keyring"/></li>
    ///     <li><c>--skip-refresh</c> via <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmDependencyUpdateSettings.Verify"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmDependencyUpdateSettings Settings, IReadOnlyCollection<Output> Output)> HelmDependencyUpdate(CombinatorialConfigure<HelmDependencyUpdateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmDependencyUpdate, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>Retrieve a package from a package repository, and download it locally. This is useful for fetching packages to inspect, modify, or repackage. It can also be used to perform cryptographic verification of a chart without installing the chart. There are options for unpacking the chart after download. This will create a directory for the chart and uncompress into that directory. If the --verify flag is specified, the requested chart MUST have a provenance file, and MUST pass the verification process. Failure in any part of this will result in an error, and the chart will not be saved locally.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;charts&gt;</c> via <see cref="HelmFetchSettings.Charts"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmFetchSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmFetchSettings.CertFile"/></li>
    ///     <li><c>--destination</c> via <see cref="HelmFetchSettings.Destination"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmFetchSettings.Devel"/></li>
    ///     <li><c>--help</c> via <see cref="HelmFetchSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmFetchSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmFetchSettings.Keyring"/></li>
    ///     <li><c>--password</c> via <see cref="HelmFetchSettings.Password"/></li>
    ///     <li><c>--prov</c> via <see cref="HelmFetchSettings.Prov"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmFetchSettings.Repo"/></li>
    ///     <li><c>--untar</c> via <see cref="HelmFetchSettings.Untar"/></li>
    ///     <li><c>--untardir</c> via <see cref="HelmFetchSettings.Untardir"/></li>
    ///     <li><c>--username</c> via <see cref="HelmFetchSettings.Username"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmFetchSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmFetchSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmFetch(HelmFetchSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmFetchSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Retrieve a package from a package repository, and download it locally. This is useful for fetching packages to inspect, modify, or repackage. It can also be used to perform cryptographic verification of a chart without installing the chart. There are options for unpacking the chart after download. This will create a directory for the chart and uncompress into that directory. If the --verify flag is specified, the requested chart MUST have a provenance file, and MUST pass the verification process. Failure in any part of this will result in an error, and the chart will not be saved locally.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;charts&gt;</c> via <see cref="HelmFetchSettings.Charts"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmFetchSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmFetchSettings.CertFile"/></li>
    ///     <li><c>--destination</c> via <see cref="HelmFetchSettings.Destination"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmFetchSettings.Devel"/></li>
    ///     <li><c>--help</c> via <see cref="HelmFetchSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmFetchSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmFetchSettings.Keyring"/></li>
    ///     <li><c>--password</c> via <see cref="HelmFetchSettings.Password"/></li>
    ///     <li><c>--prov</c> via <see cref="HelmFetchSettings.Prov"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmFetchSettings.Repo"/></li>
    ///     <li><c>--untar</c> via <see cref="HelmFetchSettings.Untar"/></li>
    ///     <li><c>--untardir</c> via <see cref="HelmFetchSettings.Untardir"/></li>
    ///     <li><c>--username</c> via <see cref="HelmFetchSettings.Username"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmFetchSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmFetchSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmFetch(Configure<HelmFetchSettings> configurator)
    {
        return HelmFetch(configurator(new HelmFetchSettings()));
    }
    /// <summary>
    ///   <p>Retrieve a package from a package repository, and download it locally. This is useful for fetching packages to inspect, modify, or repackage. It can also be used to perform cryptographic verification of a chart without installing the chart. There are options for unpacking the chart after download. This will create a directory for the chart and uncompress into that directory. If the --verify flag is specified, the requested chart MUST have a provenance file, and MUST pass the verification process. Failure in any part of this will result in an error, and the chart will not be saved locally.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;charts&gt;</c> via <see cref="HelmFetchSettings.Charts"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmFetchSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmFetchSettings.CertFile"/></li>
    ///     <li><c>--destination</c> via <see cref="HelmFetchSettings.Destination"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmFetchSettings.Devel"/></li>
    ///     <li><c>--help</c> via <see cref="HelmFetchSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmFetchSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmFetchSettings.Keyring"/></li>
    ///     <li><c>--password</c> via <see cref="HelmFetchSettings.Password"/></li>
    ///     <li><c>--prov</c> via <see cref="HelmFetchSettings.Prov"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmFetchSettings.Repo"/></li>
    ///     <li><c>--untar</c> via <see cref="HelmFetchSettings.Untar"/></li>
    ///     <li><c>--untardir</c> via <see cref="HelmFetchSettings.Untardir"/></li>
    ///     <li><c>--username</c> via <see cref="HelmFetchSettings.Username"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmFetchSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmFetchSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmFetchSettings Settings, IReadOnlyCollection<Output> Output)> HelmFetch(CombinatorialConfigure<HelmFetchSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmFetch, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command shows the details of a named release. It can be used to get extended information about the release, including:   - The values used to generate the release   - The chart used to generate the release   - The generated manifest file By default, this prints a human readable collection of information about the chart, the supplied values, and the generated manifest file.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetSettings.ReleaseName"/></li>
    ///     <li><c>--help</c> via <see cref="HelmGetSettings.Help"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmGetSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmGetSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmGetSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmGetSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmGetSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmGetSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmGetSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmGet(HelmGetSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmGetSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command shows the details of a named release. It can be used to get extended information about the release, including:   - The values used to generate the release   - The chart used to generate the release   - The generated manifest file By default, this prints a human readable collection of information about the chart, the supplied values, and the generated manifest file.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetSettings.ReleaseName"/></li>
    ///     <li><c>--help</c> via <see cref="HelmGetSettings.Help"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmGetSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmGetSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmGetSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmGetSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmGetSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmGetSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmGetSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmGet(Configure<HelmGetSettings> configurator)
    {
        return HelmGet(configurator(new HelmGetSettings()));
    }
    /// <summary>
    ///   <p>This command shows the details of a named release. It can be used to get extended information about the release, including:   - The values used to generate the release   - The chart used to generate the release   - The generated manifest file By default, this prints a human readable collection of information about the chart, the supplied values, and the generated manifest file.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetSettings.ReleaseName"/></li>
    ///     <li><c>--help</c> via <see cref="HelmGetSettings.Help"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmGetSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmGetSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmGetSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmGetSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmGetSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmGetSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmGetSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmGetSettings Settings, IReadOnlyCollection<Output> Output)> HelmGet(CombinatorialConfigure<HelmGetSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmGet, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command downloads hooks for a given release. Hooks are formatted in YAML and separated by the YAML '---\n' separator.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetHooksSettings.ReleaseName"/></li>
    ///     <li><c>--help</c> via <see cref="HelmGetHooksSettings.Help"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmGetHooksSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmGetHooksSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmGetHooksSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmGetHooksSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmGetHooksSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmGetHooksSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmGetHooksSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmGetHooks(HelmGetHooksSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmGetHooksSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command downloads hooks for a given release. Hooks are formatted in YAML and separated by the YAML '---\n' separator.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetHooksSettings.ReleaseName"/></li>
    ///     <li><c>--help</c> via <see cref="HelmGetHooksSettings.Help"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmGetHooksSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmGetHooksSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmGetHooksSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmGetHooksSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmGetHooksSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmGetHooksSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmGetHooksSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmGetHooks(Configure<HelmGetHooksSettings> configurator)
    {
        return HelmGetHooks(configurator(new HelmGetHooksSettings()));
    }
    /// <summary>
    ///   <p>This command downloads hooks for a given release. Hooks are formatted in YAML and separated by the YAML '---\n' separator.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetHooksSettings.ReleaseName"/></li>
    ///     <li><c>--help</c> via <see cref="HelmGetHooksSettings.Help"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmGetHooksSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmGetHooksSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmGetHooksSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmGetHooksSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmGetHooksSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmGetHooksSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmGetHooksSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmGetHooksSettings Settings, IReadOnlyCollection<Output> Output)> HelmGetHooks(CombinatorialConfigure<HelmGetHooksSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmGetHooks, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command fetches the generated manifest for a given release. A manifest is a YAML-encoded representation of the Kubernetes resources that were generated from this release's chart(s). If a chart is dependent on other charts, those resources will also be included in the manifest.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetManifestSettings.ReleaseName"/></li>
    ///     <li><c>--help</c> via <see cref="HelmGetManifestSettings.Help"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmGetManifestSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmGetManifestSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmGetManifestSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmGetManifestSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmGetManifestSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmGetManifestSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmGetManifestSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmGetManifest(HelmGetManifestSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmGetManifestSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command fetches the generated manifest for a given release. A manifest is a YAML-encoded representation of the Kubernetes resources that were generated from this release's chart(s). If a chart is dependent on other charts, those resources will also be included in the manifest.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetManifestSettings.ReleaseName"/></li>
    ///     <li><c>--help</c> via <see cref="HelmGetManifestSettings.Help"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmGetManifestSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmGetManifestSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmGetManifestSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmGetManifestSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmGetManifestSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmGetManifestSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmGetManifestSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmGetManifest(Configure<HelmGetManifestSettings> configurator)
    {
        return HelmGetManifest(configurator(new HelmGetManifestSettings()));
    }
    /// <summary>
    ///   <p>This command fetches the generated manifest for a given release. A manifest is a YAML-encoded representation of the Kubernetes resources that were generated from this release's chart(s). If a chart is dependent on other charts, those resources will also be included in the manifest.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetManifestSettings.ReleaseName"/></li>
    ///     <li><c>--help</c> via <see cref="HelmGetManifestSettings.Help"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmGetManifestSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmGetManifestSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmGetManifestSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmGetManifestSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmGetManifestSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmGetManifestSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmGetManifestSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmGetManifestSettings Settings, IReadOnlyCollection<Output> Output)> HelmGetManifest(CombinatorialConfigure<HelmGetManifestSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmGetManifest, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command shows notes provided by the chart of a named release.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetNotesSettings.ReleaseName"/></li>
    ///     <li><c>--help</c> via <see cref="HelmGetNotesSettings.Help"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmGetNotesSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmGetNotesSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmGetNotesSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmGetNotesSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmGetNotesSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmGetNotesSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmGetNotesSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmGetNotes(HelmGetNotesSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmGetNotesSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command shows notes provided by the chart of a named release.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetNotesSettings.ReleaseName"/></li>
    ///     <li><c>--help</c> via <see cref="HelmGetNotesSettings.Help"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmGetNotesSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmGetNotesSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmGetNotesSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmGetNotesSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmGetNotesSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmGetNotesSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmGetNotesSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmGetNotes(Configure<HelmGetNotesSettings> configurator)
    {
        return HelmGetNotes(configurator(new HelmGetNotesSettings()));
    }
    /// <summary>
    ///   <p>This command shows notes provided by the chart of a named release.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetNotesSettings.ReleaseName"/></li>
    ///     <li><c>--help</c> via <see cref="HelmGetNotesSettings.Help"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmGetNotesSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmGetNotesSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmGetNotesSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmGetNotesSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmGetNotesSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmGetNotesSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmGetNotesSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmGetNotesSettings Settings, IReadOnlyCollection<Output> Output)> HelmGetNotes(CombinatorialConfigure<HelmGetNotesSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmGetNotes, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command downloads a values file for a given release.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetValuesSettings.ReleaseName"/></li>
    ///     <li><c>--all</c> via <see cref="HelmGetValuesSettings.All"/></li>
    ///     <li><c>--help</c> via <see cref="HelmGetValuesSettings.Help"/></li>
    ///     <li><c>--output</c> via <see cref="HelmGetValuesSettings.Output"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmGetValuesSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmGetValuesSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmGetValuesSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmGetValuesSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmGetValuesSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmGetValuesSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmGetValuesSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmGetValues(HelmGetValuesSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmGetValuesSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command downloads a values file for a given release.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetValuesSettings.ReleaseName"/></li>
    ///     <li><c>--all</c> via <see cref="HelmGetValuesSettings.All"/></li>
    ///     <li><c>--help</c> via <see cref="HelmGetValuesSettings.Help"/></li>
    ///     <li><c>--output</c> via <see cref="HelmGetValuesSettings.Output"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmGetValuesSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmGetValuesSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmGetValuesSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmGetValuesSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmGetValuesSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmGetValuesSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmGetValuesSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmGetValues(Configure<HelmGetValuesSettings> configurator)
    {
        return HelmGetValues(configurator(new HelmGetValuesSettings()));
    }
    /// <summary>
    ///   <p>This command downloads a values file for a given release.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetValuesSettings.ReleaseName"/></li>
    ///     <li><c>--all</c> via <see cref="HelmGetValuesSettings.All"/></li>
    ///     <li><c>--help</c> via <see cref="HelmGetValuesSettings.Help"/></li>
    ///     <li><c>--output</c> via <see cref="HelmGetValuesSettings.Output"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmGetValuesSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmGetValuesSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmGetValuesSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmGetValuesSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmGetValuesSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmGetValuesSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmGetValuesSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmGetValuesSettings Settings, IReadOnlyCollection<Output> Output)> HelmGetValues(CombinatorialConfigure<HelmGetValuesSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmGetValues, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>History prints historical revisions for a given release. A default maximum of 256 revisions will be returned. Setting '--max' configures the maximum length of the revision list returned. The historical release set is printed as a formatted table, e.g:     $ helm history angry-bird --max=4     REVISION   UPDATED                      STATUS           CHART        DESCRIPTION     1           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Initial install     2           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Upgraded successfully     3           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Rolled back to 2     4           Mon Oct 3 10:15:13 2016     DEPLOYED        alpine-0.1.0  Upgraded successfully.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmHistorySettings.ReleaseName"/></li>
    ///     <li><c>--col-width</c> via <see cref="HelmHistorySettings.ColWidth"/></li>
    ///     <li><c>--help</c> via <see cref="HelmHistorySettings.Help"/></li>
    ///     <li><c>--max</c> via <see cref="HelmHistorySettings.Max"/></li>
    ///     <li><c>--output</c> via <see cref="HelmHistorySettings.Output"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmHistorySettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmHistorySettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmHistorySettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmHistorySettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmHistorySettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmHistorySettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmHistory(HelmHistorySettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmHistorySettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>History prints historical revisions for a given release. A default maximum of 256 revisions will be returned. Setting '--max' configures the maximum length of the revision list returned. The historical release set is printed as a formatted table, e.g:     $ helm history angry-bird --max=4     REVISION   UPDATED                      STATUS           CHART        DESCRIPTION     1           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Initial install     2           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Upgraded successfully     3           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Rolled back to 2     4           Mon Oct 3 10:15:13 2016     DEPLOYED        alpine-0.1.0  Upgraded successfully.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmHistorySettings.ReleaseName"/></li>
    ///     <li><c>--col-width</c> via <see cref="HelmHistorySettings.ColWidth"/></li>
    ///     <li><c>--help</c> via <see cref="HelmHistorySettings.Help"/></li>
    ///     <li><c>--max</c> via <see cref="HelmHistorySettings.Max"/></li>
    ///     <li><c>--output</c> via <see cref="HelmHistorySettings.Output"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmHistorySettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmHistorySettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmHistorySettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmHistorySettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmHistorySettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmHistorySettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmHistory(Configure<HelmHistorySettings> configurator)
    {
        return HelmHistory(configurator(new HelmHistorySettings()));
    }
    /// <summary>
    ///   <p>History prints historical revisions for a given release. A default maximum of 256 revisions will be returned. Setting '--max' configures the maximum length of the revision list returned. The historical release set is printed as a formatted table, e.g:     $ helm history angry-bird --max=4     REVISION   UPDATED                      STATUS           CHART        DESCRIPTION     1           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Initial install     2           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Upgraded successfully     3           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Rolled back to 2     4           Mon Oct 3 10:15:13 2016     DEPLOYED        alpine-0.1.0  Upgraded successfully.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmHistorySettings.ReleaseName"/></li>
    ///     <li><c>--col-width</c> via <see cref="HelmHistorySettings.ColWidth"/></li>
    ///     <li><c>--help</c> via <see cref="HelmHistorySettings.Help"/></li>
    ///     <li><c>--max</c> via <see cref="HelmHistorySettings.Max"/></li>
    ///     <li><c>--output</c> via <see cref="HelmHistorySettings.Output"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmHistorySettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmHistorySettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmHistorySettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmHistorySettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmHistorySettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmHistorySettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmHistorySettings Settings, IReadOnlyCollection<Output> Output)> HelmHistory(CombinatorialConfigure<HelmHistorySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmHistory, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command displays the location of HELM_HOME. This is where any helm configuration files live.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--help</c> via <see cref="HelmHomeSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmHome(HelmHomeSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmHomeSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command displays the location of HELM_HOME. This is where any helm configuration files live.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--help</c> via <see cref="HelmHomeSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmHome(Configure<HelmHomeSettings> configurator)
    {
        return HelmHome(configurator(new HelmHomeSettings()));
    }
    /// <summary>
    ///   <p>This command displays the location of HELM_HOME. This is where any helm configuration files live.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--help</c> via <see cref="HelmHomeSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmHomeSettings Settings, IReadOnlyCollection<Output> Output)> HelmHome(CombinatorialConfigure<HelmHomeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmHome, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command installs Tiller (the Helm server-side component) onto your Kubernetes Cluster and sets up local configuration in $HELM_HOME (default ~/.helm/). As with the rest of the Helm commands, 'helm init' discovers Kubernetes clusters by reading $KUBECONFIG (default '~/.kube/config') and using the default context. To set up just a local environment, use '--client-only'. That will configure $HELM_HOME, but not attempt to connect to a Kubernetes cluster and install the Tiller deployment. When installing Tiller, 'helm init' will attempt to install the latest released version. You can specify an alternative image with '--tiller-image'. For those frequently working on the latest code, the flag '--canary-image' will install the latest pre-release version of Tiller (e.g. the HEAD commit in the GitHub repository on the master branch). To dump a manifest containing the Tiller deployment YAML, combine the '--dry-run' and '--debug' flags.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--automount-service-account-token</c> via <see cref="HelmInitSettings.AutomountServiceAccountToken"/></li>
    ///     <li><c>--canary-image</c> via <see cref="HelmInitSettings.CanaryImage"/></li>
    ///     <li><c>--client-only</c> via <see cref="HelmInitSettings.ClientOnly"/></li>
    ///     <li><c>--dry-run</c> via <see cref="HelmInitSettings.DryRun"/></li>
    ///     <li><c>--force-upgrade</c> via <see cref="HelmInitSettings.ForceUpgrade"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInitSettings.Help"/></li>
    ///     <li><c>--history-max</c> via <see cref="HelmInitSettings.HistoryMax"/></li>
    ///     <li><c>--local-repo-url</c> via <see cref="HelmInitSettings.LocalRepoUrl"/></li>
    ///     <li><c>--net-host</c> via <see cref="HelmInitSettings.NetHost"/></li>
    ///     <li><c>--node-selectors</c> via <see cref="HelmInitSettings.NodeSelectors"/></li>
    ///     <li><c>--output</c> via <see cref="HelmInitSettings.Output"/></li>
    ///     <li><c>--override</c> via <see cref="HelmInitSettings.Override"/></li>
    ///     <li><c>--replicas</c> via <see cref="HelmInitSettings.Replicas"/></li>
    ///     <li><c>--service-account</c> via <see cref="HelmInitSettings.ServiceAccount"/></li>
    ///     <li><c>--skip-refresh</c> via <see cref="HelmInitSettings.SkipRefresh"/></li>
    ///     <li><c>--stable-repo-url</c> via <see cref="HelmInitSettings.StableRepoUrl"/></li>
    ///     <li><c>--tiller-image</c> via <see cref="HelmInitSettings.TillerImage"/></li>
    ///     <li><c>--tiller-tls</c> via <see cref="HelmInitSettings.TillerTls"/></li>
    ///     <li><c>--tiller-tls-cert</c> via <see cref="HelmInitSettings.TillerTlsCert"/></li>
    ///     <li><c>--tiller-tls-hostname</c> via <see cref="HelmInitSettings.TillerTlsHostname"/></li>
    ///     <li><c>--tiller-tls-key</c> via <see cref="HelmInitSettings.TillerTlsKey"/></li>
    ///     <li><c>--tiller-tls-verify</c> via <see cref="HelmInitSettings.TillerTlsVerify"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmInitSettings.TlsCaCert"/></li>
    ///     <li><c>--upgrade</c> via <see cref="HelmInitSettings.Upgrade"/></li>
    ///     <li><c>--wait</c> via <see cref="HelmInitSettings.Wait"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmInit(HelmInitSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmInitSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command installs Tiller (the Helm server-side component) onto your Kubernetes Cluster and sets up local configuration in $HELM_HOME (default ~/.helm/). As with the rest of the Helm commands, 'helm init' discovers Kubernetes clusters by reading $KUBECONFIG (default '~/.kube/config') and using the default context. To set up just a local environment, use '--client-only'. That will configure $HELM_HOME, but not attempt to connect to a Kubernetes cluster and install the Tiller deployment. When installing Tiller, 'helm init' will attempt to install the latest released version. You can specify an alternative image with '--tiller-image'. For those frequently working on the latest code, the flag '--canary-image' will install the latest pre-release version of Tiller (e.g. the HEAD commit in the GitHub repository on the master branch). To dump a manifest containing the Tiller deployment YAML, combine the '--dry-run' and '--debug' flags.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--automount-service-account-token</c> via <see cref="HelmInitSettings.AutomountServiceAccountToken"/></li>
    ///     <li><c>--canary-image</c> via <see cref="HelmInitSettings.CanaryImage"/></li>
    ///     <li><c>--client-only</c> via <see cref="HelmInitSettings.ClientOnly"/></li>
    ///     <li><c>--dry-run</c> via <see cref="HelmInitSettings.DryRun"/></li>
    ///     <li><c>--force-upgrade</c> via <see cref="HelmInitSettings.ForceUpgrade"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInitSettings.Help"/></li>
    ///     <li><c>--history-max</c> via <see cref="HelmInitSettings.HistoryMax"/></li>
    ///     <li><c>--local-repo-url</c> via <see cref="HelmInitSettings.LocalRepoUrl"/></li>
    ///     <li><c>--net-host</c> via <see cref="HelmInitSettings.NetHost"/></li>
    ///     <li><c>--node-selectors</c> via <see cref="HelmInitSettings.NodeSelectors"/></li>
    ///     <li><c>--output</c> via <see cref="HelmInitSettings.Output"/></li>
    ///     <li><c>--override</c> via <see cref="HelmInitSettings.Override"/></li>
    ///     <li><c>--replicas</c> via <see cref="HelmInitSettings.Replicas"/></li>
    ///     <li><c>--service-account</c> via <see cref="HelmInitSettings.ServiceAccount"/></li>
    ///     <li><c>--skip-refresh</c> via <see cref="HelmInitSettings.SkipRefresh"/></li>
    ///     <li><c>--stable-repo-url</c> via <see cref="HelmInitSettings.StableRepoUrl"/></li>
    ///     <li><c>--tiller-image</c> via <see cref="HelmInitSettings.TillerImage"/></li>
    ///     <li><c>--tiller-tls</c> via <see cref="HelmInitSettings.TillerTls"/></li>
    ///     <li><c>--tiller-tls-cert</c> via <see cref="HelmInitSettings.TillerTlsCert"/></li>
    ///     <li><c>--tiller-tls-hostname</c> via <see cref="HelmInitSettings.TillerTlsHostname"/></li>
    ///     <li><c>--tiller-tls-key</c> via <see cref="HelmInitSettings.TillerTlsKey"/></li>
    ///     <li><c>--tiller-tls-verify</c> via <see cref="HelmInitSettings.TillerTlsVerify"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmInitSettings.TlsCaCert"/></li>
    ///     <li><c>--upgrade</c> via <see cref="HelmInitSettings.Upgrade"/></li>
    ///     <li><c>--wait</c> via <see cref="HelmInitSettings.Wait"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmInit(Configure<HelmInitSettings> configurator)
    {
        return HelmInit(configurator(new HelmInitSettings()));
    }
    /// <summary>
    ///   <p>This command installs Tiller (the Helm server-side component) onto your Kubernetes Cluster and sets up local configuration in $HELM_HOME (default ~/.helm/). As with the rest of the Helm commands, 'helm init' discovers Kubernetes clusters by reading $KUBECONFIG (default '~/.kube/config') and using the default context. To set up just a local environment, use '--client-only'. That will configure $HELM_HOME, but not attempt to connect to a Kubernetes cluster and install the Tiller deployment. When installing Tiller, 'helm init' will attempt to install the latest released version. You can specify an alternative image with '--tiller-image'. For those frequently working on the latest code, the flag '--canary-image' will install the latest pre-release version of Tiller (e.g. the HEAD commit in the GitHub repository on the master branch). To dump a manifest containing the Tiller deployment YAML, combine the '--dry-run' and '--debug' flags.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--automount-service-account-token</c> via <see cref="HelmInitSettings.AutomountServiceAccountToken"/></li>
    ///     <li><c>--canary-image</c> via <see cref="HelmInitSettings.CanaryImage"/></li>
    ///     <li><c>--client-only</c> via <see cref="HelmInitSettings.ClientOnly"/></li>
    ///     <li><c>--dry-run</c> via <see cref="HelmInitSettings.DryRun"/></li>
    ///     <li><c>--force-upgrade</c> via <see cref="HelmInitSettings.ForceUpgrade"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInitSettings.Help"/></li>
    ///     <li><c>--history-max</c> via <see cref="HelmInitSettings.HistoryMax"/></li>
    ///     <li><c>--local-repo-url</c> via <see cref="HelmInitSettings.LocalRepoUrl"/></li>
    ///     <li><c>--net-host</c> via <see cref="HelmInitSettings.NetHost"/></li>
    ///     <li><c>--node-selectors</c> via <see cref="HelmInitSettings.NodeSelectors"/></li>
    ///     <li><c>--output</c> via <see cref="HelmInitSettings.Output"/></li>
    ///     <li><c>--override</c> via <see cref="HelmInitSettings.Override"/></li>
    ///     <li><c>--replicas</c> via <see cref="HelmInitSettings.Replicas"/></li>
    ///     <li><c>--service-account</c> via <see cref="HelmInitSettings.ServiceAccount"/></li>
    ///     <li><c>--skip-refresh</c> via <see cref="HelmInitSettings.SkipRefresh"/></li>
    ///     <li><c>--stable-repo-url</c> via <see cref="HelmInitSettings.StableRepoUrl"/></li>
    ///     <li><c>--tiller-image</c> via <see cref="HelmInitSettings.TillerImage"/></li>
    ///     <li><c>--tiller-tls</c> via <see cref="HelmInitSettings.TillerTls"/></li>
    ///     <li><c>--tiller-tls-cert</c> via <see cref="HelmInitSettings.TillerTlsCert"/></li>
    ///     <li><c>--tiller-tls-hostname</c> via <see cref="HelmInitSettings.TillerTlsHostname"/></li>
    ///     <li><c>--tiller-tls-key</c> via <see cref="HelmInitSettings.TillerTlsKey"/></li>
    ///     <li><c>--tiller-tls-verify</c> via <see cref="HelmInitSettings.TillerTlsVerify"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmInitSettings.TlsCaCert"/></li>
    ///     <li><c>--upgrade</c> via <see cref="HelmInitSettings.Upgrade"/></li>
    ///     <li><c>--wait</c> via <see cref="HelmInitSettings.Wait"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmInitSettings Settings, IReadOnlyCollection<Output> Output)> HelmInit(CombinatorialConfigure<HelmInitSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmInit, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command inspects a chart and displays information. It takes a chart reference ('stable/drupal'), a full path to a directory or packaged chart, or a URL. Inspect prints the contents of the Chart.yaml file and the values.yaml file.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInspectSettings.Chart"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmInspectSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmInspectSettings.CertFile"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmInspectSettings.Devel"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInspectSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmInspectSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmInspectSettings.Keyring"/></li>
    ///     <li><c>--password</c> via <see cref="HelmInspectSettings.Password"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmInspectSettings.Repo"/></li>
    ///     <li><c>--username</c> via <see cref="HelmInspectSettings.Username"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmInspectSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmInspectSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmInspect(HelmInspectSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmInspectSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command inspects a chart and displays information. It takes a chart reference ('stable/drupal'), a full path to a directory or packaged chart, or a URL. Inspect prints the contents of the Chart.yaml file and the values.yaml file.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInspectSettings.Chart"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmInspectSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmInspectSettings.CertFile"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmInspectSettings.Devel"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInspectSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmInspectSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmInspectSettings.Keyring"/></li>
    ///     <li><c>--password</c> via <see cref="HelmInspectSettings.Password"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmInspectSettings.Repo"/></li>
    ///     <li><c>--username</c> via <see cref="HelmInspectSettings.Username"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmInspectSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmInspectSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmInspect(Configure<HelmInspectSettings> configurator)
    {
        return HelmInspect(configurator(new HelmInspectSettings()));
    }
    /// <summary>
    ///   <p>This command inspects a chart and displays information. It takes a chart reference ('stable/drupal'), a full path to a directory or packaged chart, or a URL. Inspect prints the contents of the Chart.yaml file and the values.yaml file.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInspectSettings.Chart"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmInspectSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmInspectSettings.CertFile"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmInspectSettings.Devel"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInspectSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmInspectSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmInspectSettings.Keyring"/></li>
    ///     <li><c>--password</c> via <see cref="HelmInspectSettings.Password"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmInspectSettings.Repo"/></li>
    ///     <li><c>--username</c> via <see cref="HelmInspectSettings.Username"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmInspectSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmInspectSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmInspectSettings Settings, IReadOnlyCollection<Output> Output)> HelmInspect(CombinatorialConfigure<HelmInspectSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmInspect, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the Charts.yaml file.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInspectChartSettings.Chart"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmInspectChartSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmInspectChartSettings.CertFile"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmInspectChartSettings.Devel"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInspectChartSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmInspectChartSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmInspectChartSettings.Keyring"/></li>
    ///     <li><c>--password</c> via <see cref="HelmInspectChartSettings.Password"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmInspectChartSettings.Repo"/></li>
    ///     <li><c>--username</c> via <see cref="HelmInspectChartSettings.Username"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmInspectChartSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmInspectChartSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmInspectChart(HelmInspectChartSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmInspectChartSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the Charts.yaml file.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInspectChartSettings.Chart"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmInspectChartSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmInspectChartSettings.CertFile"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmInspectChartSettings.Devel"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInspectChartSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmInspectChartSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmInspectChartSettings.Keyring"/></li>
    ///     <li><c>--password</c> via <see cref="HelmInspectChartSettings.Password"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmInspectChartSettings.Repo"/></li>
    ///     <li><c>--username</c> via <see cref="HelmInspectChartSettings.Username"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmInspectChartSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmInspectChartSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmInspectChart(Configure<HelmInspectChartSettings> configurator)
    {
        return HelmInspectChart(configurator(new HelmInspectChartSettings()));
    }
    /// <summary>
    ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the Charts.yaml file.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInspectChartSettings.Chart"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmInspectChartSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmInspectChartSettings.CertFile"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmInspectChartSettings.Devel"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInspectChartSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmInspectChartSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmInspectChartSettings.Keyring"/></li>
    ///     <li><c>--password</c> via <see cref="HelmInspectChartSettings.Password"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmInspectChartSettings.Repo"/></li>
    ///     <li><c>--username</c> via <see cref="HelmInspectChartSettings.Username"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmInspectChartSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmInspectChartSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmInspectChartSettings Settings, IReadOnlyCollection<Output> Output)> HelmInspectChart(CombinatorialConfigure<HelmInspectChartSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmInspectChart, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the README file.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInspectReadmeSettings.Chart"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmInspectReadmeSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmInspectReadmeSettings.CertFile"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmInspectReadmeSettings.Devel"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInspectReadmeSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmInspectReadmeSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmInspectReadmeSettings.Keyring"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmInspectReadmeSettings.Repo"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmInspectReadmeSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmInspectReadmeSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmInspectReadme(HelmInspectReadmeSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmInspectReadmeSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the README file.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInspectReadmeSettings.Chart"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmInspectReadmeSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmInspectReadmeSettings.CertFile"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmInspectReadmeSettings.Devel"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInspectReadmeSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmInspectReadmeSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmInspectReadmeSettings.Keyring"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmInspectReadmeSettings.Repo"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmInspectReadmeSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmInspectReadmeSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmInspectReadme(Configure<HelmInspectReadmeSettings> configurator)
    {
        return HelmInspectReadme(configurator(new HelmInspectReadmeSettings()));
    }
    /// <summary>
    ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the README file.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInspectReadmeSettings.Chart"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmInspectReadmeSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmInspectReadmeSettings.CertFile"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmInspectReadmeSettings.Devel"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInspectReadmeSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmInspectReadmeSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmInspectReadmeSettings.Keyring"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmInspectReadmeSettings.Repo"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmInspectReadmeSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmInspectReadmeSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmInspectReadmeSettings Settings, IReadOnlyCollection<Output> Output)> HelmInspectReadme(CombinatorialConfigure<HelmInspectReadmeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmInspectReadme, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the values.yaml file.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInspectValuesSettings.Chart"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmInspectValuesSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmInspectValuesSettings.CertFile"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmInspectValuesSettings.Devel"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInspectValuesSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmInspectValuesSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmInspectValuesSettings.Keyring"/></li>
    ///     <li><c>--password</c> via <see cref="HelmInspectValuesSettings.Password"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmInspectValuesSettings.Repo"/></li>
    ///     <li><c>--username</c> via <see cref="HelmInspectValuesSettings.Username"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmInspectValuesSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmInspectValuesSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmInspectValues(HelmInspectValuesSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmInspectValuesSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the values.yaml file.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInspectValuesSettings.Chart"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmInspectValuesSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmInspectValuesSettings.CertFile"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmInspectValuesSettings.Devel"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInspectValuesSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmInspectValuesSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmInspectValuesSettings.Keyring"/></li>
    ///     <li><c>--password</c> via <see cref="HelmInspectValuesSettings.Password"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmInspectValuesSettings.Repo"/></li>
    ///     <li><c>--username</c> via <see cref="HelmInspectValuesSettings.Username"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmInspectValuesSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmInspectValuesSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmInspectValues(Configure<HelmInspectValuesSettings> configurator)
    {
        return HelmInspectValues(configurator(new HelmInspectValuesSettings()));
    }
    /// <summary>
    ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the values.yaml file.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInspectValuesSettings.Chart"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmInspectValuesSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmInspectValuesSettings.CertFile"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmInspectValuesSettings.Devel"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInspectValuesSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmInspectValuesSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmInspectValuesSettings.Keyring"/></li>
    ///     <li><c>--password</c> via <see cref="HelmInspectValuesSettings.Password"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmInspectValuesSettings.Repo"/></li>
    ///     <li><c>--username</c> via <see cref="HelmInspectValuesSettings.Username"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmInspectValuesSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmInspectValuesSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmInspectValuesSettings Settings, IReadOnlyCollection<Output> Output)> HelmInspectValues(CombinatorialConfigure<HelmInspectValuesSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmInspectValues, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command installs a chart archive. The install argument must be a chart reference, a path to a packaged chart, a path to an unpacked chart directory or a URL. To override values in a chart, use either the '--values' flag and pass in a file or use the '--set' flag and pass configuration from the command line.  To force string values in '--set', use '--set-string' instead. In case a value is large and therefore you want not to use neither '--values' nor '--set', use '--set-file' to read the single large value from file. 	$ helm install -f myvalues.yaml ./redis or 	$ helm install --set name=prod ./redis or 	$ helm install --set-string long_int=1234567890 ./redis or     $ helm install --set-file multiline_text=path/to/textfile You can specify the '--values'/'-f' flag multiple times. The priority will be given to the last (right-most) file specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence: 	$ helm install -f myvalues.yaml -f override.yaml ./redis You can specify the '--set' flag multiple times. The priority will be given to the last (right-most) set specified. For example, if both 'bar' and 'newbar' values are set for a key called 'foo', the 'newbar' value would take precedence: 	$ helm install --set foo=bar --set foo=newbar ./redis To check the generated manifests of a release without installing the chart, the '--debug' and '--dry-run' flags can be combined. This will still require a round-trip to the Tiller server. If --verify is set, the chart MUST have a provenance file, and the provenance file MUST pass all verification steps. There are five different ways you can express the chart you want to install: 1. By chart reference: helm install stable/mariadb 2. By path to a packaged chart: helm install ./nginx-1.2.3.tgz 3. By path to an unpacked chart directory: helm install ./nginx 4. By absolute URL: helm install https://example.com/charts/nginx-1.2.3.tgz 5. By chart reference and repo url: helm install --repo https://example.com/charts/ nginx CHART REFERENCES A chart reference is a convenient way of reference a chart in a chart repository. When you use a chart reference with a repo prefix ('stable/mariadb'), Helm will look in the local configuration for a chart repository named 'stable', and will then look for a chart in that repository whose name is 'mariadb'. It will install the latest version of that chart unless you also supply a version number with the '--version' flag. To see the list of chart repositories, use 'helm repo list'. To search for charts in a repository, use 'helm search'.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInstallSettings.Chart"/></li>
    ///     <li><c>--atomic</c> via <see cref="HelmInstallSettings.Atomic"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmInstallSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmInstallSettings.CertFile"/></li>
    ///     <li><c>--dep-up</c> via <see cref="HelmInstallSettings.DepUp"/></li>
    ///     <li><c>--description</c> via <see cref="HelmInstallSettings.Description"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmInstallSettings.Devel"/></li>
    ///     <li><c>--dry-run</c> via <see cref="HelmInstallSettings.DryRun"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInstallSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmInstallSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmInstallSettings.Keyring"/></li>
    ///     <li><c>--name</c> via <see cref="HelmInstallSettings.Name"/></li>
    ///     <li><c>--name-template</c> via <see cref="HelmInstallSettings.NameTemplate"/></li>
    ///     <li><c>--namespace</c> via <see cref="HelmInstallSettings.Namespace"/></li>
    ///     <li><c>--no-crd-hook</c> via <see cref="HelmInstallSettings.NoCrdHook"/></li>
    ///     <li><c>--no-hooks</c> via <see cref="HelmInstallSettings.NoHooks"/></li>
    ///     <li><c>--password</c> via <see cref="HelmInstallSettings.Password"/></li>
    ///     <li><c>--render-subchart-notes</c> via <see cref="HelmInstallSettings.RenderSubchartNotes"/></li>
    ///     <li><c>--replace</c> via <see cref="HelmInstallSettings.Replace"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmInstallSettings.Repo"/></li>
    ///     <li><c>--set</c> via <see cref="HelmInstallSettings.Set"/></li>
    ///     <li><c>--set-file</c> via <see cref="HelmInstallSettings.SetFile"/></li>
    ///     <li><c>--set-string</c> via <see cref="HelmInstallSettings.SetString"/></li>
    ///     <li><c>--timeout</c> via <see cref="HelmInstallSettings.Timeout"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmInstallSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmInstallSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmInstallSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmInstallSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmInstallSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmInstallSettings.TlsVerify"/></li>
    ///     <li><c>--username</c> via <see cref="HelmInstallSettings.Username"/></li>
    ///     <li><c>--values</c> via <see cref="HelmInstallSettings.Values"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmInstallSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmInstallSettings.Version"/></li>
    ///     <li><c>--wait</c> via <see cref="HelmInstallSettings.Wait"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmInstall(HelmInstallSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmInstallSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command installs a chart archive. The install argument must be a chart reference, a path to a packaged chart, a path to an unpacked chart directory or a URL. To override values in a chart, use either the '--values' flag and pass in a file or use the '--set' flag and pass configuration from the command line.  To force string values in '--set', use '--set-string' instead. In case a value is large and therefore you want not to use neither '--values' nor '--set', use '--set-file' to read the single large value from file. 	$ helm install -f myvalues.yaml ./redis or 	$ helm install --set name=prod ./redis or 	$ helm install --set-string long_int=1234567890 ./redis or     $ helm install --set-file multiline_text=path/to/textfile You can specify the '--values'/'-f' flag multiple times. The priority will be given to the last (right-most) file specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence: 	$ helm install -f myvalues.yaml -f override.yaml ./redis You can specify the '--set' flag multiple times. The priority will be given to the last (right-most) set specified. For example, if both 'bar' and 'newbar' values are set for a key called 'foo', the 'newbar' value would take precedence: 	$ helm install --set foo=bar --set foo=newbar ./redis To check the generated manifests of a release without installing the chart, the '--debug' and '--dry-run' flags can be combined. This will still require a round-trip to the Tiller server. If --verify is set, the chart MUST have a provenance file, and the provenance file MUST pass all verification steps. There are five different ways you can express the chart you want to install: 1. By chart reference: helm install stable/mariadb 2. By path to a packaged chart: helm install ./nginx-1.2.3.tgz 3. By path to an unpacked chart directory: helm install ./nginx 4. By absolute URL: helm install https://example.com/charts/nginx-1.2.3.tgz 5. By chart reference and repo url: helm install --repo https://example.com/charts/ nginx CHART REFERENCES A chart reference is a convenient way of reference a chart in a chart repository. When you use a chart reference with a repo prefix ('stable/mariadb'), Helm will look in the local configuration for a chart repository named 'stable', and will then look for a chart in that repository whose name is 'mariadb'. It will install the latest version of that chart unless you also supply a version number with the '--version' flag. To see the list of chart repositories, use 'helm repo list'. To search for charts in a repository, use 'helm search'.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInstallSettings.Chart"/></li>
    ///     <li><c>--atomic</c> via <see cref="HelmInstallSettings.Atomic"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmInstallSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmInstallSettings.CertFile"/></li>
    ///     <li><c>--dep-up</c> via <see cref="HelmInstallSettings.DepUp"/></li>
    ///     <li><c>--description</c> via <see cref="HelmInstallSettings.Description"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmInstallSettings.Devel"/></li>
    ///     <li><c>--dry-run</c> via <see cref="HelmInstallSettings.DryRun"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInstallSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmInstallSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmInstallSettings.Keyring"/></li>
    ///     <li><c>--name</c> via <see cref="HelmInstallSettings.Name"/></li>
    ///     <li><c>--name-template</c> via <see cref="HelmInstallSettings.NameTemplate"/></li>
    ///     <li><c>--namespace</c> via <see cref="HelmInstallSettings.Namespace"/></li>
    ///     <li><c>--no-crd-hook</c> via <see cref="HelmInstallSettings.NoCrdHook"/></li>
    ///     <li><c>--no-hooks</c> via <see cref="HelmInstallSettings.NoHooks"/></li>
    ///     <li><c>--password</c> via <see cref="HelmInstallSettings.Password"/></li>
    ///     <li><c>--render-subchart-notes</c> via <see cref="HelmInstallSettings.RenderSubchartNotes"/></li>
    ///     <li><c>--replace</c> via <see cref="HelmInstallSettings.Replace"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmInstallSettings.Repo"/></li>
    ///     <li><c>--set</c> via <see cref="HelmInstallSettings.Set"/></li>
    ///     <li><c>--set-file</c> via <see cref="HelmInstallSettings.SetFile"/></li>
    ///     <li><c>--set-string</c> via <see cref="HelmInstallSettings.SetString"/></li>
    ///     <li><c>--timeout</c> via <see cref="HelmInstallSettings.Timeout"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmInstallSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmInstallSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmInstallSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmInstallSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmInstallSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmInstallSettings.TlsVerify"/></li>
    ///     <li><c>--username</c> via <see cref="HelmInstallSettings.Username"/></li>
    ///     <li><c>--values</c> via <see cref="HelmInstallSettings.Values"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmInstallSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmInstallSettings.Version"/></li>
    ///     <li><c>--wait</c> via <see cref="HelmInstallSettings.Wait"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmInstall(Configure<HelmInstallSettings> configurator)
    {
        return HelmInstall(configurator(new HelmInstallSettings()));
    }
    /// <summary>
    ///   <p>This command installs a chart archive. The install argument must be a chart reference, a path to a packaged chart, a path to an unpacked chart directory or a URL. To override values in a chart, use either the '--values' flag and pass in a file or use the '--set' flag and pass configuration from the command line.  To force string values in '--set', use '--set-string' instead. In case a value is large and therefore you want not to use neither '--values' nor '--set', use '--set-file' to read the single large value from file. 	$ helm install -f myvalues.yaml ./redis or 	$ helm install --set name=prod ./redis or 	$ helm install --set-string long_int=1234567890 ./redis or     $ helm install --set-file multiline_text=path/to/textfile You can specify the '--values'/'-f' flag multiple times. The priority will be given to the last (right-most) file specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence: 	$ helm install -f myvalues.yaml -f override.yaml ./redis You can specify the '--set' flag multiple times. The priority will be given to the last (right-most) set specified. For example, if both 'bar' and 'newbar' values are set for a key called 'foo', the 'newbar' value would take precedence: 	$ helm install --set foo=bar --set foo=newbar ./redis To check the generated manifests of a release without installing the chart, the '--debug' and '--dry-run' flags can be combined. This will still require a round-trip to the Tiller server. If --verify is set, the chart MUST have a provenance file, and the provenance file MUST pass all verification steps. There are five different ways you can express the chart you want to install: 1. By chart reference: helm install stable/mariadb 2. By path to a packaged chart: helm install ./nginx-1.2.3.tgz 3. By path to an unpacked chart directory: helm install ./nginx 4. By absolute URL: helm install https://example.com/charts/nginx-1.2.3.tgz 5. By chart reference and repo url: helm install --repo https://example.com/charts/ nginx CHART REFERENCES A chart reference is a convenient way of reference a chart in a chart repository. When you use a chart reference with a repo prefix ('stable/mariadb'), Helm will look in the local configuration for a chart repository named 'stable', and will then look for a chart in that repository whose name is 'mariadb'. It will install the latest version of that chart unless you also supply a version number with the '--version' flag. To see the list of chart repositories, use 'helm repo list'. To search for charts in a repository, use 'helm search'.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInstallSettings.Chart"/></li>
    ///     <li><c>--atomic</c> via <see cref="HelmInstallSettings.Atomic"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmInstallSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmInstallSettings.CertFile"/></li>
    ///     <li><c>--dep-up</c> via <see cref="HelmInstallSettings.DepUp"/></li>
    ///     <li><c>--description</c> via <see cref="HelmInstallSettings.Description"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmInstallSettings.Devel"/></li>
    ///     <li><c>--dry-run</c> via <see cref="HelmInstallSettings.DryRun"/></li>
    ///     <li><c>--help</c> via <see cref="HelmInstallSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmInstallSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmInstallSettings.Keyring"/></li>
    ///     <li><c>--name</c> via <see cref="HelmInstallSettings.Name"/></li>
    ///     <li><c>--name-template</c> via <see cref="HelmInstallSettings.NameTemplate"/></li>
    ///     <li><c>--namespace</c> via <see cref="HelmInstallSettings.Namespace"/></li>
    ///     <li><c>--no-crd-hook</c> via <see cref="HelmInstallSettings.NoCrdHook"/></li>
    ///     <li><c>--no-hooks</c> via <see cref="HelmInstallSettings.NoHooks"/></li>
    ///     <li><c>--password</c> via <see cref="HelmInstallSettings.Password"/></li>
    ///     <li><c>--render-subchart-notes</c> via <see cref="HelmInstallSettings.RenderSubchartNotes"/></li>
    ///     <li><c>--replace</c> via <see cref="HelmInstallSettings.Replace"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmInstallSettings.Repo"/></li>
    ///     <li><c>--set</c> via <see cref="HelmInstallSettings.Set"/></li>
    ///     <li><c>--set-file</c> via <see cref="HelmInstallSettings.SetFile"/></li>
    ///     <li><c>--set-string</c> via <see cref="HelmInstallSettings.SetString"/></li>
    ///     <li><c>--timeout</c> via <see cref="HelmInstallSettings.Timeout"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmInstallSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmInstallSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmInstallSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmInstallSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmInstallSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmInstallSettings.TlsVerify"/></li>
    ///     <li><c>--username</c> via <see cref="HelmInstallSettings.Username"/></li>
    ///     <li><c>--values</c> via <see cref="HelmInstallSettings.Values"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmInstallSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmInstallSettings.Version"/></li>
    ///     <li><c>--wait</c> via <see cref="HelmInstallSettings.Wait"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmInstallSettings Settings, IReadOnlyCollection<Output> Output)> HelmInstall(CombinatorialConfigure<HelmInstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmInstall, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command takes a path to a chart and runs a series of tests to verify that the chart is well-formed. If the linter encounters things that will cause the chart to fail installation, it will emit [ERROR] messages. If it encounters issues that break with convention or recommendation, it will emit [WARNING] messages.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;path&gt;</c> via <see cref="HelmLintSettings.Path"/></li>
    ///     <li><c>--help</c> via <see cref="HelmLintSettings.Help"/></li>
    ///     <li><c>--namespace</c> via <see cref="HelmLintSettings.Namespace"/></li>
    ///     <li><c>--set</c> via <see cref="HelmLintSettings.Set"/></li>
    ///     <li><c>--set-file</c> via <see cref="HelmLintSettings.SetFile"/></li>
    ///     <li><c>--set-string</c> via <see cref="HelmLintSettings.SetString"/></li>
    ///     <li><c>--strict</c> via <see cref="HelmLintSettings.Strict"/></li>
    ///     <li><c>--values</c> via <see cref="HelmLintSettings.Values"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmLint(HelmLintSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmLintSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command takes a path to a chart and runs a series of tests to verify that the chart is well-formed. If the linter encounters things that will cause the chart to fail installation, it will emit [ERROR] messages. If it encounters issues that break with convention or recommendation, it will emit [WARNING] messages.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;path&gt;</c> via <see cref="HelmLintSettings.Path"/></li>
    ///     <li><c>--help</c> via <see cref="HelmLintSettings.Help"/></li>
    ///     <li><c>--namespace</c> via <see cref="HelmLintSettings.Namespace"/></li>
    ///     <li><c>--set</c> via <see cref="HelmLintSettings.Set"/></li>
    ///     <li><c>--set-file</c> via <see cref="HelmLintSettings.SetFile"/></li>
    ///     <li><c>--set-string</c> via <see cref="HelmLintSettings.SetString"/></li>
    ///     <li><c>--strict</c> via <see cref="HelmLintSettings.Strict"/></li>
    ///     <li><c>--values</c> via <see cref="HelmLintSettings.Values"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmLint(Configure<HelmLintSettings> configurator)
    {
        return HelmLint(configurator(new HelmLintSettings()));
    }
    /// <summary>
    ///   <p>This command takes a path to a chart and runs a series of tests to verify that the chart is well-formed. If the linter encounters things that will cause the chart to fail installation, it will emit [ERROR] messages. If it encounters issues that break with convention or recommendation, it will emit [WARNING] messages.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;path&gt;</c> via <see cref="HelmLintSettings.Path"/></li>
    ///     <li><c>--help</c> via <see cref="HelmLintSettings.Help"/></li>
    ///     <li><c>--namespace</c> via <see cref="HelmLintSettings.Namespace"/></li>
    ///     <li><c>--set</c> via <see cref="HelmLintSettings.Set"/></li>
    ///     <li><c>--set-file</c> via <see cref="HelmLintSettings.SetFile"/></li>
    ///     <li><c>--set-string</c> via <see cref="HelmLintSettings.SetString"/></li>
    ///     <li><c>--strict</c> via <see cref="HelmLintSettings.Strict"/></li>
    ///     <li><c>--values</c> via <see cref="HelmLintSettings.Values"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmLintSettings Settings, IReadOnlyCollection<Output> Output)> HelmLint(CombinatorialConfigure<HelmLintSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmLint, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command lists all of the releases. By default, it lists only releases that are deployed or failed. Flags like '--deleted' and '--all' will alter this behavior. Such flags can be combined: '--deleted --failed'. By default, items are sorted alphabetically. Use the '-d' flag to sort by release date. If an argument is provided, it will be treated as a filter. Filters are regular expressions (Perl compatible) that are applied to the list of releases. Only items that match the filter will be returned. 	$ helm list 'ara[a-z]+' 	NAME            	UPDATED                 	CHART 	maudlin-arachnid	Mon May  9 16:07:08 2016	alpine-0.1.0 If no results are found, 'helm list' will exit 0, but with no output (or in the case of no '-q' flag, only headers). By default, up to 256 items may be returned. To limit this, use the '--max' flag. Setting '--max' to 0 will not return all results. Rather, it will return the server's default, which may be much higher than 256. Pairing the '--max' flag with the '--offset' flag allows you to page through results.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;filter&gt;</c> via <see cref="HelmListSettings.Filter"/></li>
    ///     <li><c>--all</c> via <see cref="HelmListSettings.All"/></li>
    ///     <li><c>--chart-name</c> via <see cref="HelmListSettings.ChartName"/></li>
    ///     <li><c>--col-width</c> via <see cref="HelmListSettings.ColWidth"/></li>
    ///     <li><c>--date</c> via <see cref="HelmListSettings.Date"/></li>
    ///     <li><c>--deleted</c> via <see cref="HelmListSettings.Deleted"/></li>
    ///     <li><c>--deleting</c> via <see cref="HelmListSettings.Deleting"/></li>
    ///     <li><c>--deployed</c> via <see cref="HelmListSettings.Deployed"/></li>
    ///     <li><c>--failed</c> via <see cref="HelmListSettings.Failed"/></li>
    ///     <li><c>--help</c> via <see cref="HelmListSettings.Help"/></li>
    ///     <li><c>--max</c> via <see cref="HelmListSettings.Max"/></li>
    ///     <li><c>--namespace</c> via <see cref="HelmListSettings.Namespace"/></li>
    ///     <li><c>--offset</c> via <see cref="HelmListSettings.Offset"/></li>
    ///     <li><c>--output</c> via <see cref="HelmListSettings.Output"/></li>
    ///     <li><c>--pending</c> via <see cref="HelmListSettings.Pending"/></li>
    ///     <li><c>--reverse</c> via <see cref="HelmListSettings.Reverse"/></li>
    ///     <li><c>--short</c> via <see cref="HelmListSettings.Short"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmListSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmListSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmListSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmListSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmListSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmListSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmList(HelmListSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmListSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command lists all of the releases. By default, it lists only releases that are deployed or failed. Flags like '--deleted' and '--all' will alter this behavior. Such flags can be combined: '--deleted --failed'. By default, items are sorted alphabetically. Use the '-d' flag to sort by release date. If an argument is provided, it will be treated as a filter. Filters are regular expressions (Perl compatible) that are applied to the list of releases. Only items that match the filter will be returned. 	$ helm list 'ara[a-z]+' 	NAME            	UPDATED                 	CHART 	maudlin-arachnid	Mon May  9 16:07:08 2016	alpine-0.1.0 If no results are found, 'helm list' will exit 0, but with no output (or in the case of no '-q' flag, only headers). By default, up to 256 items may be returned. To limit this, use the '--max' flag. Setting '--max' to 0 will not return all results. Rather, it will return the server's default, which may be much higher than 256. Pairing the '--max' flag with the '--offset' flag allows you to page through results.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;filter&gt;</c> via <see cref="HelmListSettings.Filter"/></li>
    ///     <li><c>--all</c> via <see cref="HelmListSettings.All"/></li>
    ///     <li><c>--chart-name</c> via <see cref="HelmListSettings.ChartName"/></li>
    ///     <li><c>--col-width</c> via <see cref="HelmListSettings.ColWidth"/></li>
    ///     <li><c>--date</c> via <see cref="HelmListSettings.Date"/></li>
    ///     <li><c>--deleted</c> via <see cref="HelmListSettings.Deleted"/></li>
    ///     <li><c>--deleting</c> via <see cref="HelmListSettings.Deleting"/></li>
    ///     <li><c>--deployed</c> via <see cref="HelmListSettings.Deployed"/></li>
    ///     <li><c>--failed</c> via <see cref="HelmListSettings.Failed"/></li>
    ///     <li><c>--help</c> via <see cref="HelmListSettings.Help"/></li>
    ///     <li><c>--max</c> via <see cref="HelmListSettings.Max"/></li>
    ///     <li><c>--namespace</c> via <see cref="HelmListSettings.Namespace"/></li>
    ///     <li><c>--offset</c> via <see cref="HelmListSettings.Offset"/></li>
    ///     <li><c>--output</c> via <see cref="HelmListSettings.Output"/></li>
    ///     <li><c>--pending</c> via <see cref="HelmListSettings.Pending"/></li>
    ///     <li><c>--reverse</c> via <see cref="HelmListSettings.Reverse"/></li>
    ///     <li><c>--short</c> via <see cref="HelmListSettings.Short"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmListSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmListSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmListSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmListSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmListSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmListSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmList(Configure<HelmListSettings> configurator)
    {
        return HelmList(configurator(new HelmListSettings()));
    }
    /// <summary>
    ///   <p>This command lists all of the releases. By default, it lists only releases that are deployed or failed. Flags like '--deleted' and '--all' will alter this behavior. Such flags can be combined: '--deleted --failed'. By default, items are sorted alphabetically. Use the '-d' flag to sort by release date. If an argument is provided, it will be treated as a filter. Filters are regular expressions (Perl compatible) that are applied to the list of releases. Only items that match the filter will be returned. 	$ helm list 'ara[a-z]+' 	NAME            	UPDATED                 	CHART 	maudlin-arachnid	Mon May  9 16:07:08 2016	alpine-0.1.0 If no results are found, 'helm list' will exit 0, but with no output (or in the case of no '-q' flag, only headers). By default, up to 256 items may be returned. To limit this, use the '--max' flag. Setting '--max' to 0 will not return all results. Rather, it will return the server's default, which may be much higher than 256. Pairing the '--max' flag with the '--offset' flag allows you to page through results.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;filter&gt;</c> via <see cref="HelmListSettings.Filter"/></li>
    ///     <li><c>--all</c> via <see cref="HelmListSettings.All"/></li>
    ///     <li><c>--chart-name</c> via <see cref="HelmListSettings.ChartName"/></li>
    ///     <li><c>--col-width</c> via <see cref="HelmListSettings.ColWidth"/></li>
    ///     <li><c>--date</c> via <see cref="HelmListSettings.Date"/></li>
    ///     <li><c>--deleted</c> via <see cref="HelmListSettings.Deleted"/></li>
    ///     <li><c>--deleting</c> via <see cref="HelmListSettings.Deleting"/></li>
    ///     <li><c>--deployed</c> via <see cref="HelmListSettings.Deployed"/></li>
    ///     <li><c>--failed</c> via <see cref="HelmListSettings.Failed"/></li>
    ///     <li><c>--help</c> via <see cref="HelmListSettings.Help"/></li>
    ///     <li><c>--max</c> via <see cref="HelmListSettings.Max"/></li>
    ///     <li><c>--namespace</c> via <see cref="HelmListSettings.Namespace"/></li>
    ///     <li><c>--offset</c> via <see cref="HelmListSettings.Offset"/></li>
    ///     <li><c>--output</c> via <see cref="HelmListSettings.Output"/></li>
    ///     <li><c>--pending</c> via <see cref="HelmListSettings.Pending"/></li>
    ///     <li><c>--reverse</c> via <see cref="HelmListSettings.Reverse"/></li>
    ///     <li><c>--short</c> via <see cref="HelmListSettings.Short"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmListSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmListSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmListSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmListSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmListSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmListSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmListSettings Settings, IReadOnlyCollection<Output> Output)> HelmList(CombinatorialConfigure<HelmListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmList, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command packages a chart into a versioned chart archive file. If a path is given, this will look at that path for a chart (which must contain a Chart.yaml file) and then package that directory. If no path is given, this will look in the present working directory for a Chart.yaml file, and (if found) build the current directory into a chart. Versioned chart archives are used by Helm package repositories.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chartPaths&gt;</c> via <see cref="HelmPackageSettings.ChartPaths"/></li>
    ///     <li><c>--app-version</c> via <see cref="HelmPackageSettings.AppVersion"/></li>
    ///     <li><c>--dependency-update</c> via <see cref="HelmPackageSettings.DependencyUpdate"/></li>
    ///     <li><c>--destination</c> via <see cref="HelmPackageSettings.Destination"/></li>
    ///     <li><c>--help</c> via <see cref="HelmPackageSettings.Help"/></li>
    ///     <li><c>--key</c> via <see cref="HelmPackageSettings.Key"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmPackageSettings.Keyring"/></li>
    ///     <li><c>--save</c> via <see cref="HelmPackageSettings.Save"/></li>
    ///     <li><c>--sign</c> via <see cref="HelmPackageSettings.Sign"/></li>
    ///     <li><c>--version</c> via <see cref="HelmPackageSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmPackage(HelmPackageSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmPackageSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command packages a chart into a versioned chart archive file. If a path is given, this will look at that path for a chart (which must contain a Chart.yaml file) and then package that directory. If no path is given, this will look in the present working directory for a Chart.yaml file, and (if found) build the current directory into a chart. Versioned chart archives are used by Helm package repositories.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chartPaths&gt;</c> via <see cref="HelmPackageSettings.ChartPaths"/></li>
    ///     <li><c>--app-version</c> via <see cref="HelmPackageSettings.AppVersion"/></li>
    ///     <li><c>--dependency-update</c> via <see cref="HelmPackageSettings.DependencyUpdate"/></li>
    ///     <li><c>--destination</c> via <see cref="HelmPackageSettings.Destination"/></li>
    ///     <li><c>--help</c> via <see cref="HelmPackageSettings.Help"/></li>
    ///     <li><c>--key</c> via <see cref="HelmPackageSettings.Key"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmPackageSettings.Keyring"/></li>
    ///     <li><c>--save</c> via <see cref="HelmPackageSettings.Save"/></li>
    ///     <li><c>--sign</c> via <see cref="HelmPackageSettings.Sign"/></li>
    ///     <li><c>--version</c> via <see cref="HelmPackageSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmPackage(Configure<HelmPackageSettings> configurator)
    {
        return HelmPackage(configurator(new HelmPackageSettings()));
    }
    /// <summary>
    ///   <p>This command packages a chart into a versioned chart archive file. If a path is given, this will look at that path for a chart (which must contain a Chart.yaml file) and then package that directory. If no path is given, this will look in the present working directory for a Chart.yaml file, and (if found) build the current directory into a chart. Versioned chart archives are used by Helm package repositories.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chartPaths&gt;</c> via <see cref="HelmPackageSettings.ChartPaths"/></li>
    ///     <li><c>--app-version</c> via <see cref="HelmPackageSettings.AppVersion"/></li>
    ///     <li><c>--dependency-update</c> via <see cref="HelmPackageSettings.DependencyUpdate"/></li>
    ///     <li><c>--destination</c> via <see cref="HelmPackageSettings.Destination"/></li>
    ///     <li><c>--help</c> via <see cref="HelmPackageSettings.Help"/></li>
    ///     <li><c>--key</c> via <see cref="HelmPackageSettings.Key"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmPackageSettings.Keyring"/></li>
    ///     <li><c>--save</c> via <see cref="HelmPackageSettings.Save"/></li>
    ///     <li><c>--sign</c> via <see cref="HelmPackageSettings.Sign"/></li>
    ///     <li><c>--version</c> via <see cref="HelmPackageSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmPackageSettings Settings, IReadOnlyCollection<Output> Output)> HelmPackage(CombinatorialConfigure<HelmPackageSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmPackage, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command allows you to install a plugin from a url to a VCS repo or a local path. Example usage:     $ helm plugin install https://github.com/technosophos/helm-template.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;options&gt;</c> via <see cref="HelmPluginInstallSettings.Options"/></li>
    ///     <li><c>&lt;paths&gt;</c> via <see cref="HelmPluginInstallSettings.Paths"/></li>
    ///     <li><c>--help</c> via <see cref="HelmPluginInstallSettings.Help"/></li>
    ///     <li><c>--version</c> via <see cref="HelmPluginInstallSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmPluginInstall(HelmPluginInstallSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmPluginInstallSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command allows you to install a plugin from a url to a VCS repo or a local path. Example usage:     $ helm plugin install https://github.com/technosophos/helm-template.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;options&gt;</c> via <see cref="HelmPluginInstallSettings.Options"/></li>
    ///     <li><c>&lt;paths&gt;</c> via <see cref="HelmPluginInstallSettings.Paths"/></li>
    ///     <li><c>--help</c> via <see cref="HelmPluginInstallSettings.Help"/></li>
    ///     <li><c>--version</c> via <see cref="HelmPluginInstallSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmPluginInstall(Configure<HelmPluginInstallSettings> configurator)
    {
        return HelmPluginInstall(configurator(new HelmPluginInstallSettings()));
    }
    /// <summary>
    ///   <p>This command allows you to install a plugin from a url to a VCS repo or a local path. Example usage:     $ helm plugin install https://github.com/technosophos/helm-template.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;options&gt;</c> via <see cref="HelmPluginInstallSettings.Options"/></li>
    ///     <li><c>&lt;paths&gt;</c> via <see cref="HelmPluginInstallSettings.Paths"/></li>
    ///     <li><c>--help</c> via <see cref="HelmPluginInstallSettings.Help"/></li>
    ///     <li><c>--version</c> via <see cref="HelmPluginInstallSettings.Version"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmPluginInstallSettings Settings, IReadOnlyCollection<Output> Output)> HelmPluginInstall(CombinatorialConfigure<HelmPluginInstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmPluginInstall, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>List installed Helm plugins.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--help</c> via <see cref="HelmPluginListSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmPluginList(HelmPluginListSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmPluginListSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>List installed Helm plugins.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--help</c> via <see cref="HelmPluginListSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmPluginList(Configure<HelmPluginListSettings> configurator)
    {
        return HelmPluginList(configurator(new HelmPluginListSettings()));
    }
    /// <summary>
    ///   <p>List installed Helm plugins.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--help</c> via <see cref="HelmPluginListSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmPluginListSettings Settings, IReadOnlyCollection<Output> Output)> HelmPluginList(CombinatorialConfigure<HelmPluginListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmPluginList, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>Remove one or more Helm plugins.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginRemoveSettings.Plugins"/></li>
    ///     <li><c>--help</c> via <see cref="HelmPluginRemoveSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmPluginRemove(HelmPluginRemoveSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmPluginRemoveSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Remove one or more Helm plugins.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginRemoveSettings.Plugins"/></li>
    ///     <li><c>--help</c> via <see cref="HelmPluginRemoveSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmPluginRemove(Configure<HelmPluginRemoveSettings> configurator)
    {
        return HelmPluginRemove(configurator(new HelmPluginRemoveSettings()));
    }
    /// <summary>
    ///   <p>Remove one or more Helm plugins.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginRemoveSettings.Plugins"/></li>
    ///     <li><c>--help</c> via <see cref="HelmPluginRemoveSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmPluginRemoveSettings Settings, IReadOnlyCollection<Output> Output)> HelmPluginRemove(CombinatorialConfigure<HelmPluginRemoveSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmPluginRemove, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>Update one or more Helm plugins.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginUpdateSettings.Plugins"/></li>
    ///     <li><c>--help</c> via <see cref="HelmPluginUpdateSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmPluginUpdate(HelmPluginUpdateSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmPluginUpdateSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Update one or more Helm plugins.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginUpdateSettings.Plugins"/></li>
    ///     <li><c>--help</c> via <see cref="HelmPluginUpdateSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmPluginUpdate(Configure<HelmPluginUpdateSettings> configurator)
    {
        return HelmPluginUpdate(configurator(new HelmPluginUpdateSettings()));
    }
    /// <summary>
    ///   <p>Update one or more Helm plugins.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginUpdateSettings.Plugins"/></li>
    ///     <li><c>--help</c> via <see cref="HelmPluginUpdateSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmPluginUpdateSettings Settings, IReadOnlyCollection<Output> Output)> HelmPluginUpdate(CombinatorialConfigure<HelmPluginUpdateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmPluginUpdate, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>Add a chart repository.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;name&gt;</c> via <see cref="HelmRepoAddSettings.Name"/></li>
    ///     <li><c>&lt;url&gt;</c> via <see cref="HelmRepoAddSettings.Url"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmRepoAddSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmRepoAddSettings.CertFile"/></li>
    ///     <li><c>--help</c> via <see cref="HelmRepoAddSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmRepoAddSettings.KeyFile"/></li>
    ///     <li><c>--no-update</c> via <see cref="HelmRepoAddSettings.NoUpdate"/></li>
    ///     <li><c>--password</c> via <see cref="HelmRepoAddSettings.Password"/></li>
    ///     <li><c>--username</c> via <see cref="HelmRepoAddSettings.Username"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmRepoAdd(HelmRepoAddSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmRepoAddSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Add a chart repository.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;name&gt;</c> via <see cref="HelmRepoAddSettings.Name"/></li>
    ///     <li><c>&lt;url&gt;</c> via <see cref="HelmRepoAddSettings.Url"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmRepoAddSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmRepoAddSettings.CertFile"/></li>
    ///     <li><c>--help</c> via <see cref="HelmRepoAddSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmRepoAddSettings.KeyFile"/></li>
    ///     <li><c>--no-update</c> via <see cref="HelmRepoAddSettings.NoUpdate"/></li>
    ///     <li><c>--password</c> via <see cref="HelmRepoAddSettings.Password"/></li>
    ///     <li><c>--username</c> via <see cref="HelmRepoAddSettings.Username"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmRepoAdd(Configure<HelmRepoAddSettings> configurator)
    {
        return HelmRepoAdd(configurator(new HelmRepoAddSettings()));
    }
    /// <summary>
    ///   <p>Add a chart repository.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;name&gt;</c> via <see cref="HelmRepoAddSettings.Name"/></li>
    ///     <li><c>&lt;url&gt;</c> via <see cref="HelmRepoAddSettings.Url"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmRepoAddSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmRepoAddSettings.CertFile"/></li>
    ///     <li><c>--help</c> via <see cref="HelmRepoAddSettings.Help"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmRepoAddSettings.KeyFile"/></li>
    ///     <li><c>--no-update</c> via <see cref="HelmRepoAddSettings.NoUpdate"/></li>
    ///     <li><c>--password</c> via <see cref="HelmRepoAddSettings.Password"/></li>
    ///     <li><c>--username</c> via <see cref="HelmRepoAddSettings.Username"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmRepoAddSettings Settings, IReadOnlyCollection<Output> Output)> HelmRepoAdd(CombinatorialConfigure<HelmRepoAddSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmRepoAdd, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>Read the current directory and generate an index file based on the charts found. This tool is used for creating an 'index.yaml' file for a chart repository. To set an absolute URL to the charts, use '--url' flag. To merge the generated index with an existing index file, use the '--merge' flag. In this case, the charts found in the current directory will be merged into the existing index, with local charts taking priority over existing charts.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;directory&gt;</c> via <see cref="HelmRepoIndexSettings.Directory"/></li>
    ///     <li><c>--help</c> via <see cref="HelmRepoIndexSettings.Help"/></li>
    ///     <li><c>--merge</c> via <see cref="HelmRepoIndexSettings.Merge"/></li>
    ///     <li><c>--url</c> via <see cref="HelmRepoIndexSettings.Url"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmRepoIndex(HelmRepoIndexSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmRepoIndexSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Read the current directory and generate an index file based on the charts found. This tool is used for creating an 'index.yaml' file for a chart repository. To set an absolute URL to the charts, use '--url' flag. To merge the generated index with an existing index file, use the '--merge' flag. In this case, the charts found in the current directory will be merged into the existing index, with local charts taking priority over existing charts.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;directory&gt;</c> via <see cref="HelmRepoIndexSettings.Directory"/></li>
    ///     <li><c>--help</c> via <see cref="HelmRepoIndexSettings.Help"/></li>
    ///     <li><c>--merge</c> via <see cref="HelmRepoIndexSettings.Merge"/></li>
    ///     <li><c>--url</c> via <see cref="HelmRepoIndexSettings.Url"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmRepoIndex(Configure<HelmRepoIndexSettings> configurator)
    {
        return HelmRepoIndex(configurator(new HelmRepoIndexSettings()));
    }
    /// <summary>
    ///   <p>Read the current directory and generate an index file based on the charts found. This tool is used for creating an 'index.yaml' file for a chart repository. To set an absolute URL to the charts, use '--url' flag. To merge the generated index with an existing index file, use the '--merge' flag. In this case, the charts found in the current directory will be merged into the existing index, with local charts taking priority over existing charts.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;directory&gt;</c> via <see cref="HelmRepoIndexSettings.Directory"/></li>
    ///     <li><c>--help</c> via <see cref="HelmRepoIndexSettings.Help"/></li>
    ///     <li><c>--merge</c> via <see cref="HelmRepoIndexSettings.Merge"/></li>
    ///     <li><c>--url</c> via <see cref="HelmRepoIndexSettings.Url"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmRepoIndexSettings Settings, IReadOnlyCollection<Output> Output)> HelmRepoIndex(CombinatorialConfigure<HelmRepoIndexSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmRepoIndex, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>List chart repositories.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--help</c> via <see cref="HelmRepoListSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmRepoList(HelmRepoListSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmRepoListSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>List chart repositories.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--help</c> via <see cref="HelmRepoListSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmRepoList(Configure<HelmRepoListSettings> configurator)
    {
        return HelmRepoList(configurator(new HelmRepoListSettings()));
    }
    /// <summary>
    ///   <p>List chart repositories.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--help</c> via <see cref="HelmRepoListSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmRepoListSettings Settings, IReadOnlyCollection<Output> Output)> HelmRepoList(CombinatorialConfigure<HelmRepoListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmRepoList, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>Remove a chart repository.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;name&gt;</c> via <see cref="HelmRepoRemoveSettings.Name"/></li>
    ///     <li><c>--help</c> via <see cref="HelmRepoRemoveSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmRepoRemove(HelmRepoRemoveSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmRepoRemoveSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Remove a chart repository.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;name&gt;</c> via <see cref="HelmRepoRemoveSettings.Name"/></li>
    ///     <li><c>--help</c> via <see cref="HelmRepoRemoveSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmRepoRemove(Configure<HelmRepoRemoveSettings> configurator)
    {
        return HelmRepoRemove(configurator(new HelmRepoRemoveSettings()));
    }
    /// <summary>
    ///   <p>Remove a chart repository.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;name&gt;</c> via <see cref="HelmRepoRemoveSettings.Name"/></li>
    ///     <li><c>--help</c> via <see cref="HelmRepoRemoveSettings.Help"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmRepoRemoveSettings Settings, IReadOnlyCollection<Output> Output)> HelmRepoRemove(CombinatorialConfigure<HelmRepoRemoveSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmRepoRemove, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>Update gets the latest information about charts from the respective chart repositories. Information is cached locally, where it is used by commands like 'helm search'. 'helm update' is the deprecated form of 'helm repo update'. It will be removed in future releases.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--help</c> via <see cref="HelmRepoUpdateSettings.Help"/></li>
    ///     <li><c>--strict</c> via <see cref="HelmRepoUpdateSettings.Strict"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmRepoUpdate(HelmRepoUpdateSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmRepoUpdateSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Update gets the latest information about charts from the respective chart repositories. Information is cached locally, where it is used by commands like 'helm search'. 'helm update' is the deprecated form of 'helm repo update'. It will be removed in future releases.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--help</c> via <see cref="HelmRepoUpdateSettings.Help"/></li>
    ///     <li><c>--strict</c> via <see cref="HelmRepoUpdateSettings.Strict"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmRepoUpdate(Configure<HelmRepoUpdateSettings> configurator)
    {
        return HelmRepoUpdate(configurator(new HelmRepoUpdateSettings()));
    }
    /// <summary>
    ///   <p>Update gets the latest information about charts from the respective chart repositories. Information is cached locally, where it is used by commands like 'helm search'. 'helm update' is the deprecated form of 'helm repo update'. It will be removed in future releases.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--help</c> via <see cref="HelmRepoUpdateSettings.Help"/></li>
    ///     <li><c>--strict</c> via <see cref="HelmRepoUpdateSettings.Strict"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmRepoUpdateSettings Settings, IReadOnlyCollection<Output> Output)> HelmRepoUpdate(CombinatorialConfigure<HelmRepoUpdateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmRepoUpdate, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command uninstalls Tiller (the Helm server-side component) from your Kubernetes Cluster and optionally deletes local configuration in $HELM_HOME (default ~/.helm/).</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--force</c> via <see cref="HelmResetSettings.Force"/></li>
    ///     <li><c>--help</c> via <see cref="HelmResetSettings.Help"/></li>
    ///     <li><c>--remove-helm-home</c> via <see cref="HelmResetSettings.RemoveHelmHome"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmResetSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmResetSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmResetSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmResetSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmResetSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmResetSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmReset(HelmResetSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmResetSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command uninstalls Tiller (the Helm server-side component) from your Kubernetes Cluster and optionally deletes local configuration in $HELM_HOME (default ~/.helm/).</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--force</c> via <see cref="HelmResetSettings.Force"/></li>
    ///     <li><c>--help</c> via <see cref="HelmResetSettings.Help"/></li>
    ///     <li><c>--remove-helm-home</c> via <see cref="HelmResetSettings.RemoveHelmHome"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmResetSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmResetSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmResetSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmResetSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmResetSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmResetSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmReset(Configure<HelmResetSettings> configurator)
    {
        return HelmReset(configurator(new HelmResetSettings()));
    }
    /// <summary>
    ///   <p>This command uninstalls Tiller (the Helm server-side component) from your Kubernetes Cluster and optionally deletes local configuration in $HELM_HOME (default ~/.helm/).</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--force</c> via <see cref="HelmResetSettings.Force"/></li>
    ///     <li><c>--help</c> via <see cref="HelmResetSettings.Help"/></li>
    ///     <li><c>--remove-helm-home</c> via <see cref="HelmResetSettings.RemoveHelmHome"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmResetSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmResetSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmResetSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmResetSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmResetSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmResetSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmResetSettings Settings, IReadOnlyCollection<Output> Output)> HelmReset(CombinatorialConfigure<HelmResetSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmReset, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command rolls back a release to a previous revision. The first argument of the rollback command is the name of a release, and the second is a revision (version) number. To see revision numbers, run 'helm history RELEASE'. If you'd like to rollback to the previous release use 'helm rollback [RELEASE] 0'.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;release&gt;</c> via <see cref="HelmRollbackSettings.Release"/></li>
    ///     <li><c>&lt;revision&gt;</c> via <see cref="HelmRollbackSettings.Revision"/></li>
    ///     <li><c>--description</c> via <see cref="HelmRollbackSettings.Description"/></li>
    ///     <li><c>--dry-run</c> via <see cref="HelmRollbackSettings.DryRun"/></li>
    ///     <li><c>--force</c> via <see cref="HelmRollbackSettings.Force"/></li>
    ///     <li><c>--help</c> via <see cref="HelmRollbackSettings.Help"/></li>
    ///     <li><c>--no-hooks</c> via <see cref="HelmRollbackSettings.NoHooks"/></li>
    ///     <li><c>--recreate-pods</c> via <see cref="HelmRollbackSettings.RecreatePods"/></li>
    ///     <li><c>--timeout</c> via <see cref="HelmRollbackSettings.Timeout"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmRollbackSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmRollbackSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmRollbackSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmRollbackSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmRollbackSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmRollbackSettings.TlsVerify"/></li>
    ///     <li><c>--wait</c> via <see cref="HelmRollbackSettings.Wait"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmRollback(HelmRollbackSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmRollbackSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command rolls back a release to a previous revision. The first argument of the rollback command is the name of a release, and the second is a revision (version) number. To see revision numbers, run 'helm history RELEASE'. If you'd like to rollback to the previous release use 'helm rollback [RELEASE] 0'.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;release&gt;</c> via <see cref="HelmRollbackSettings.Release"/></li>
    ///     <li><c>&lt;revision&gt;</c> via <see cref="HelmRollbackSettings.Revision"/></li>
    ///     <li><c>--description</c> via <see cref="HelmRollbackSettings.Description"/></li>
    ///     <li><c>--dry-run</c> via <see cref="HelmRollbackSettings.DryRun"/></li>
    ///     <li><c>--force</c> via <see cref="HelmRollbackSettings.Force"/></li>
    ///     <li><c>--help</c> via <see cref="HelmRollbackSettings.Help"/></li>
    ///     <li><c>--no-hooks</c> via <see cref="HelmRollbackSettings.NoHooks"/></li>
    ///     <li><c>--recreate-pods</c> via <see cref="HelmRollbackSettings.RecreatePods"/></li>
    ///     <li><c>--timeout</c> via <see cref="HelmRollbackSettings.Timeout"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmRollbackSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmRollbackSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmRollbackSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmRollbackSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmRollbackSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmRollbackSettings.TlsVerify"/></li>
    ///     <li><c>--wait</c> via <see cref="HelmRollbackSettings.Wait"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmRollback(Configure<HelmRollbackSettings> configurator)
    {
        return HelmRollback(configurator(new HelmRollbackSettings()));
    }
    /// <summary>
    ///   <p>This command rolls back a release to a previous revision. The first argument of the rollback command is the name of a release, and the second is a revision (version) number. To see revision numbers, run 'helm history RELEASE'. If you'd like to rollback to the previous release use 'helm rollback [RELEASE] 0'.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;release&gt;</c> via <see cref="HelmRollbackSettings.Release"/></li>
    ///     <li><c>&lt;revision&gt;</c> via <see cref="HelmRollbackSettings.Revision"/></li>
    ///     <li><c>--description</c> via <see cref="HelmRollbackSettings.Description"/></li>
    ///     <li><c>--dry-run</c> via <see cref="HelmRollbackSettings.DryRun"/></li>
    ///     <li><c>--force</c> via <see cref="HelmRollbackSettings.Force"/></li>
    ///     <li><c>--help</c> via <see cref="HelmRollbackSettings.Help"/></li>
    ///     <li><c>--no-hooks</c> via <see cref="HelmRollbackSettings.NoHooks"/></li>
    ///     <li><c>--recreate-pods</c> via <see cref="HelmRollbackSettings.RecreatePods"/></li>
    ///     <li><c>--timeout</c> via <see cref="HelmRollbackSettings.Timeout"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmRollbackSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmRollbackSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmRollbackSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmRollbackSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmRollbackSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmRollbackSettings.TlsVerify"/></li>
    ///     <li><c>--wait</c> via <see cref="HelmRollbackSettings.Wait"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmRollbackSettings Settings, IReadOnlyCollection<Output> Output)> HelmRollback(CombinatorialConfigure<HelmRollbackSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmRollback, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>Search reads through all of the repositories configured on the system, and looks for matches. Repositories are managed with 'helm repo' commands.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;keyword&gt;</c> via <see cref="HelmSearchSettings.Keyword"/></li>
    ///     <li><c>--col-width</c> via <see cref="HelmSearchSettings.ColWidth"/></li>
    ///     <li><c>--help</c> via <see cref="HelmSearchSettings.Help"/></li>
    ///     <li><c>--regexp</c> via <see cref="HelmSearchSettings.Regexp"/></li>
    ///     <li><c>--version</c> via <see cref="HelmSearchSettings.Version"/></li>
    ///     <li><c>--versions</c> via <see cref="HelmSearchSettings.Versions"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmSearch(HelmSearchSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmSearchSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Search reads through all of the repositories configured on the system, and looks for matches. Repositories are managed with 'helm repo' commands.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;keyword&gt;</c> via <see cref="HelmSearchSettings.Keyword"/></li>
    ///     <li><c>--col-width</c> via <see cref="HelmSearchSettings.ColWidth"/></li>
    ///     <li><c>--help</c> via <see cref="HelmSearchSettings.Help"/></li>
    ///     <li><c>--regexp</c> via <see cref="HelmSearchSettings.Regexp"/></li>
    ///     <li><c>--version</c> via <see cref="HelmSearchSettings.Version"/></li>
    ///     <li><c>--versions</c> via <see cref="HelmSearchSettings.Versions"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmSearch(Configure<HelmSearchSettings> configurator)
    {
        return HelmSearch(configurator(new HelmSearchSettings()));
    }
    /// <summary>
    ///   <p>Search reads through all of the repositories configured on the system, and looks for matches. Repositories are managed with 'helm repo' commands.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;keyword&gt;</c> via <see cref="HelmSearchSettings.Keyword"/></li>
    ///     <li><c>--col-width</c> via <see cref="HelmSearchSettings.ColWidth"/></li>
    ///     <li><c>--help</c> via <see cref="HelmSearchSettings.Help"/></li>
    ///     <li><c>--regexp</c> via <see cref="HelmSearchSettings.Regexp"/></li>
    ///     <li><c>--version</c> via <see cref="HelmSearchSettings.Version"/></li>
    ///     <li><c>--versions</c> via <see cref="HelmSearchSettings.Versions"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmSearchSettings Settings, IReadOnlyCollection<Output> Output)> HelmSearch(CombinatorialConfigure<HelmSearchSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmSearch, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command starts a local chart repository server that serves charts from a local directory. The new server will provide HTTP access to a repository. By default, it will scan all of the charts in '$HELM_HOME/repository/local' and serve those over the local IPv4 TCP port (default '127.0.0.1:8879'). This command is intended to be used for educational and testing purposes only. It is best to rely on a dedicated web server or a cloud-hosted solution like Google Cloud Storage for production use. See https://github.com/helm/helm/blob/master/docs/chart_repository.md#hosting-chart-repositories for more information on hosting chart repositories in a production setting.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--address</c> via <see cref="HelmServeSettings.Address"/></li>
    ///     <li><c>--help</c> via <see cref="HelmServeSettings.Help"/></li>
    ///     <li><c>--repo-path</c> via <see cref="HelmServeSettings.RepoPath"/></li>
    ///     <li><c>--url</c> via <see cref="HelmServeSettings.Url"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmServe(HelmServeSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmServeSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command starts a local chart repository server that serves charts from a local directory. The new server will provide HTTP access to a repository. By default, it will scan all of the charts in '$HELM_HOME/repository/local' and serve those over the local IPv4 TCP port (default '127.0.0.1:8879'). This command is intended to be used for educational and testing purposes only. It is best to rely on a dedicated web server or a cloud-hosted solution like Google Cloud Storage for production use. See https://github.com/helm/helm/blob/master/docs/chart_repository.md#hosting-chart-repositories for more information on hosting chart repositories in a production setting.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--address</c> via <see cref="HelmServeSettings.Address"/></li>
    ///     <li><c>--help</c> via <see cref="HelmServeSettings.Help"/></li>
    ///     <li><c>--repo-path</c> via <see cref="HelmServeSettings.RepoPath"/></li>
    ///     <li><c>--url</c> via <see cref="HelmServeSettings.Url"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmServe(Configure<HelmServeSettings> configurator)
    {
        return HelmServe(configurator(new HelmServeSettings()));
    }
    /// <summary>
    ///   <p>This command starts a local chart repository server that serves charts from a local directory. The new server will provide HTTP access to a repository. By default, it will scan all of the charts in '$HELM_HOME/repository/local' and serve those over the local IPv4 TCP port (default '127.0.0.1:8879'). This command is intended to be used for educational and testing purposes only. It is best to rely on a dedicated web server or a cloud-hosted solution like Google Cloud Storage for production use. See https://github.com/helm/helm/blob/master/docs/chart_repository.md#hosting-chart-repositories for more information on hosting chart repositories in a production setting.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--address</c> via <see cref="HelmServeSettings.Address"/></li>
    ///     <li><c>--help</c> via <see cref="HelmServeSettings.Help"/></li>
    ///     <li><c>--repo-path</c> via <see cref="HelmServeSettings.RepoPath"/></li>
    ///     <li><c>--url</c> via <see cref="HelmServeSettings.Url"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmServeSettings Settings, IReadOnlyCollection<Output> Output)> HelmServe(CombinatorialConfigure<HelmServeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmServe, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command shows the status of a named release. The status consists of: - last deployment time - k8s namespace in which the release lives - state of the release (can be: UNKNOWN, DEPLOYED, DELETED, SUPERSEDED, FAILED or DELETING) - list of resources that this release consists of, sorted by kind - details on last test suite run, if applicable - additional notes provided by the chart.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmStatusSettings.ReleaseName"/></li>
    ///     <li><c>--help</c> via <see cref="HelmStatusSettings.Help"/></li>
    ///     <li><c>--output</c> via <see cref="HelmStatusSettings.Output"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmStatusSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmStatusSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmStatusSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmStatusSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmStatusSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmStatusSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmStatusSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmStatus(HelmStatusSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmStatusSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command shows the status of a named release. The status consists of: - last deployment time - k8s namespace in which the release lives - state of the release (can be: UNKNOWN, DEPLOYED, DELETED, SUPERSEDED, FAILED or DELETING) - list of resources that this release consists of, sorted by kind - details on last test suite run, if applicable - additional notes provided by the chart.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmStatusSettings.ReleaseName"/></li>
    ///     <li><c>--help</c> via <see cref="HelmStatusSettings.Help"/></li>
    ///     <li><c>--output</c> via <see cref="HelmStatusSettings.Output"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmStatusSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmStatusSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmStatusSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmStatusSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmStatusSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmStatusSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmStatusSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmStatus(Configure<HelmStatusSettings> configurator)
    {
        return HelmStatus(configurator(new HelmStatusSettings()));
    }
    /// <summary>
    ///   <p>This command shows the status of a named release. The status consists of: - last deployment time - k8s namespace in which the release lives - state of the release (can be: UNKNOWN, DEPLOYED, DELETED, SUPERSEDED, FAILED or DELETING) - list of resources that this release consists of, sorted by kind - details on last test suite run, if applicable - additional notes provided by the chart.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmStatusSettings.ReleaseName"/></li>
    ///     <li><c>--help</c> via <see cref="HelmStatusSettings.Help"/></li>
    ///     <li><c>--output</c> via <see cref="HelmStatusSettings.Output"/></li>
    ///     <li><c>--revision</c> via <see cref="HelmStatusSettings.Revision"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmStatusSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmStatusSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmStatusSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmStatusSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmStatusSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmStatusSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmStatusSettings Settings, IReadOnlyCollection<Output> Output)> HelmStatus(CombinatorialConfigure<HelmStatusSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmStatus, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>Render chart templates locally and display the output. This does not require Tiller. However, any values that would normally be looked up or retrieved in-cluster will be faked locally. Additionally, none of the server-side testing of chart validity (e.g. whether an API is supported) is done. To render just one template in a chart, use '-x': 	$ helm template mychart -x templates/deployment.yaml.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmTemplateSettings.Chart"/></li>
    ///     <li><c>--execute</c> via <see cref="HelmTemplateSettings.Execute"/></li>
    ///     <li><c>--help</c> via <see cref="HelmTemplateSettings.Help"/></li>
    ///     <li><c>--is-upgrade</c> via <see cref="HelmTemplateSettings.IsUpgrade"/></li>
    ///     <li><c>--kube-version</c> via <see cref="HelmTemplateSettings.KubeVersion"/></li>
    ///     <li><c>--name</c> via <see cref="HelmTemplateSettings.Name"/></li>
    ///     <li><c>--name-template</c> via <see cref="HelmTemplateSettings.NameTemplate"/></li>
    ///     <li><c>--namespace</c> via <see cref="HelmTemplateSettings.Namespace"/></li>
    ///     <li><c>--notes</c> via <see cref="HelmTemplateSettings.Notes"/></li>
    ///     <li><c>--output-dir</c> via <see cref="HelmTemplateSettings.OutputDir"/></li>
    ///     <li><c>--set</c> via <see cref="HelmTemplateSettings.Set"/></li>
    ///     <li><c>--set-file</c> via <see cref="HelmTemplateSettings.SetFile"/></li>
    ///     <li><c>--set-string</c> via <see cref="HelmTemplateSettings.SetString"/></li>
    ///     <li><c>--values</c> via <see cref="HelmTemplateSettings.Values"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmTemplate(HelmTemplateSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmTemplateSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Render chart templates locally and display the output. This does not require Tiller. However, any values that would normally be looked up or retrieved in-cluster will be faked locally. Additionally, none of the server-side testing of chart validity (e.g. whether an API is supported) is done. To render just one template in a chart, use '-x': 	$ helm template mychart -x templates/deployment.yaml.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmTemplateSettings.Chart"/></li>
    ///     <li><c>--execute</c> via <see cref="HelmTemplateSettings.Execute"/></li>
    ///     <li><c>--help</c> via <see cref="HelmTemplateSettings.Help"/></li>
    ///     <li><c>--is-upgrade</c> via <see cref="HelmTemplateSettings.IsUpgrade"/></li>
    ///     <li><c>--kube-version</c> via <see cref="HelmTemplateSettings.KubeVersion"/></li>
    ///     <li><c>--name</c> via <see cref="HelmTemplateSettings.Name"/></li>
    ///     <li><c>--name-template</c> via <see cref="HelmTemplateSettings.NameTemplate"/></li>
    ///     <li><c>--namespace</c> via <see cref="HelmTemplateSettings.Namespace"/></li>
    ///     <li><c>--notes</c> via <see cref="HelmTemplateSettings.Notes"/></li>
    ///     <li><c>--output-dir</c> via <see cref="HelmTemplateSettings.OutputDir"/></li>
    ///     <li><c>--set</c> via <see cref="HelmTemplateSettings.Set"/></li>
    ///     <li><c>--set-file</c> via <see cref="HelmTemplateSettings.SetFile"/></li>
    ///     <li><c>--set-string</c> via <see cref="HelmTemplateSettings.SetString"/></li>
    ///     <li><c>--values</c> via <see cref="HelmTemplateSettings.Values"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmTemplate(Configure<HelmTemplateSettings> configurator)
    {
        return HelmTemplate(configurator(new HelmTemplateSettings()));
    }
    /// <summary>
    ///   <p>Render chart templates locally and display the output. This does not require Tiller. However, any values that would normally be looked up or retrieved in-cluster will be faked locally. Additionally, none of the server-side testing of chart validity (e.g. whether an API is supported) is done. To render just one template in a chart, use '-x': 	$ helm template mychart -x templates/deployment.yaml.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmTemplateSettings.Chart"/></li>
    ///     <li><c>--execute</c> via <see cref="HelmTemplateSettings.Execute"/></li>
    ///     <li><c>--help</c> via <see cref="HelmTemplateSettings.Help"/></li>
    ///     <li><c>--is-upgrade</c> via <see cref="HelmTemplateSettings.IsUpgrade"/></li>
    ///     <li><c>--kube-version</c> via <see cref="HelmTemplateSettings.KubeVersion"/></li>
    ///     <li><c>--name</c> via <see cref="HelmTemplateSettings.Name"/></li>
    ///     <li><c>--name-template</c> via <see cref="HelmTemplateSettings.NameTemplate"/></li>
    ///     <li><c>--namespace</c> via <see cref="HelmTemplateSettings.Namespace"/></li>
    ///     <li><c>--notes</c> via <see cref="HelmTemplateSettings.Notes"/></li>
    ///     <li><c>--output-dir</c> via <see cref="HelmTemplateSettings.OutputDir"/></li>
    ///     <li><c>--set</c> via <see cref="HelmTemplateSettings.Set"/></li>
    ///     <li><c>--set-file</c> via <see cref="HelmTemplateSettings.SetFile"/></li>
    ///     <li><c>--set-string</c> via <see cref="HelmTemplateSettings.SetString"/></li>
    ///     <li><c>--values</c> via <see cref="HelmTemplateSettings.Values"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmTemplateSettings Settings, IReadOnlyCollection<Output> Output)> HelmTemplate(CombinatorialConfigure<HelmTemplateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmTemplate, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>The test command runs the tests for a release. The argument this command takes is the name of a deployed release. The tests to be run are defined in the chart that was installed.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;release&gt;</c> via <see cref="HelmTestSettings.Release"/></li>
    ///     <li><c>--cleanup</c> via <see cref="HelmTestSettings.Cleanup"/></li>
    ///     <li><c>--help</c> via <see cref="HelmTestSettings.Help"/></li>
    ///     <li><c>--parallel</c> via <see cref="HelmTestSettings.Parallel"/></li>
    ///     <li><c>--timeout</c> via <see cref="HelmTestSettings.Timeout"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmTestSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmTestSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmTestSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmTestSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmTestSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmTestSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmTest(HelmTestSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmTestSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>The test command runs the tests for a release. The argument this command takes is the name of a deployed release. The tests to be run are defined in the chart that was installed.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;release&gt;</c> via <see cref="HelmTestSettings.Release"/></li>
    ///     <li><c>--cleanup</c> via <see cref="HelmTestSettings.Cleanup"/></li>
    ///     <li><c>--help</c> via <see cref="HelmTestSettings.Help"/></li>
    ///     <li><c>--parallel</c> via <see cref="HelmTestSettings.Parallel"/></li>
    ///     <li><c>--timeout</c> via <see cref="HelmTestSettings.Timeout"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmTestSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmTestSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmTestSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmTestSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmTestSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmTestSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmTest(Configure<HelmTestSettings> configurator)
    {
        return HelmTest(configurator(new HelmTestSettings()));
    }
    /// <summary>
    ///   <p>The test command runs the tests for a release. The argument this command takes is the name of a deployed release. The tests to be run are defined in the chart that was installed.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;release&gt;</c> via <see cref="HelmTestSettings.Release"/></li>
    ///     <li><c>--cleanup</c> via <see cref="HelmTestSettings.Cleanup"/></li>
    ///     <li><c>--help</c> via <see cref="HelmTestSettings.Help"/></li>
    ///     <li><c>--parallel</c> via <see cref="HelmTestSettings.Parallel"/></li>
    ///     <li><c>--timeout</c> via <see cref="HelmTestSettings.Timeout"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmTestSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmTestSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmTestSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmTestSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmTestSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmTestSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmTestSettings Settings, IReadOnlyCollection<Output> Output)> HelmTest(CombinatorialConfigure<HelmTestSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmTest, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>This command upgrades a release to a specified version of a chart and/or updates chart values. Required arguments are release and chart. The chart argument can be one of:  - a chart reference('stable/mariadb'); use '--version' and '--devel' flags for versions other than latest,  - a path to a chart directory,  - a packaged chart,  - a fully qualified URL. To customize the chart values, use any of  - '--values'/'-f' to pass in a yaml file holding settings,  - '--set' to provide one or more key=val pairs directly,  - '--set-string' to provide key=val forcing val to be stored as a string,  - '--set-file' to provide key=path to read a single large value from a file at path. To edit or append to the existing customized values, add the  '--reuse-values' flag, otherwise any existing customized values are ignored. If no chart value arguments are provided on the command line, any existing customized values are carried forward. If you want to revert to just the values provided in the chart, use the '--reset-values' flag. You can specify any of the chart value flags multiple times. The priority will be given to the last (right-most) value specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence: 	$ helm upgrade -f myvalues.yaml -f override.yaml redis ./redis Note that the key name provided to the '--set', '--set-string' and '--set-file' flags can reference structure elements. Examples:   - mybool=TRUE   - livenessProbe.timeoutSeconds=10   - metrics.annotations[0]=hey,metrics.annotations[1]=ho which sets the top level key mybool to true, the nested timeoutSeconds to 10, and two array values, respectively. Note that the value side of the key=val provided to '--set' and '--set-string' flags will pass through shell evaluation followed by yaml type parsing to produce the final value. This may alter inputs with special characters in unexpected ways, for example 	$ helm upgrade --set pwd=3jk$o2,z=f\30.e redis ./redis results in "pwd: 3jk" and "z: f30.e". Use single quotes to avoid shell evaluation and argument delimiters, and use backslash to escape yaml special characters: 	$ helm upgrade --set pwd='3jk$o2z=f\\30.e' redis ./redis which results in the expected "pwd: 3jk$o2z=f\30.e". If a single quote occurs in your value then follow your shell convention for escaping it; for example in bash: 	$ helm upgrade --set pwd='3jk$o2z=f\\30with'\''quote' which results in "pwd: 3jk$o2z=f\30with'quote".</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmUpgradeSettings.Chart"/></li>
    ///     <li><c>&lt;release&gt;</c> via <see cref="HelmUpgradeSettings.Release"/></li>
    ///     <li><c>--atomic</c> via <see cref="HelmUpgradeSettings.Atomic"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmUpgradeSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmUpgradeSettings.CertFile"/></li>
    ///     <li><c>--create-namespace</c> via <see cref="HelmUpgradeSettings.CreateNamespace"/></li>
    ///     <li><c>--description</c> via <see cref="HelmUpgradeSettings.Description"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmUpgradeSettings.Devel"/></li>
    ///     <li><c>--dry-run</c> via <see cref="HelmUpgradeSettings.DryRun"/></li>
    ///     <li><c>--force</c> via <see cref="HelmUpgradeSettings.Force"/></li>
    ///     <li><c>--help</c> via <see cref="HelmUpgradeSettings.Help"/></li>
    ///     <li><c>--install</c> via <see cref="HelmUpgradeSettings.Install"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmUpgradeSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmUpgradeSettings.Keyring"/></li>
    ///     <li><c>--namespace</c> via <see cref="HelmUpgradeSettings.Namespace"/></li>
    ///     <li><c>--no-hooks</c> via <see cref="HelmUpgradeSettings.NoHooks"/></li>
    ///     <li><c>--password</c> via <see cref="HelmUpgradeSettings.Password"/></li>
    ///     <li><c>--recreate-pods</c> via <see cref="HelmUpgradeSettings.RecreatePods"/></li>
    ///     <li><c>--render-subchart-notes</c> via <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmUpgradeSettings.Repo"/></li>
    ///     <li><c>--reset-values</c> via <see cref="HelmUpgradeSettings.ResetValues"/></li>
    ///     <li><c>--reuse-values</c> via <see cref="HelmUpgradeSettings.ReuseValues"/></li>
    ///     <li><c>--set</c> via <see cref="HelmUpgradeSettings.Set"/></li>
    ///     <li><c>--set-file</c> via <see cref="HelmUpgradeSettings.SetFile"/></li>
    ///     <li><c>--set-string</c> via <see cref="HelmUpgradeSettings.SetString"/></li>
    ///     <li><c>--timeout</c> via <see cref="HelmUpgradeSettings.Timeout"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmUpgradeSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmUpgradeSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmUpgradeSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmUpgradeSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmUpgradeSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmUpgradeSettings.TlsVerify"/></li>
    ///     <li><c>--username</c> via <see cref="HelmUpgradeSettings.Username"/></li>
    ///     <li><c>--values</c> via <see cref="HelmUpgradeSettings.Values"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmUpgradeSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmUpgradeSettings.Version"/></li>
    ///     <li><c>--wait</c> via <see cref="HelmUpgradeSettings.Wait"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmUpgrade(HelmUpgradeSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmUpgradeSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>This command upgrades a release to a specified version of a chart and/or updates chart values. Required arguments are release and chart. The chart argument can be one of:  - a chart reference('stable/mariadb'); use '--version' and '--devel' flags for versions other than latest,  - a path to a chart directory,  - a packaged chart,  - a fully qualified URL. To customize the chart values, use any of  - '--values'/'-f' to pass in a yaml file holding settings,  - '--set' to provide one or more key=val pairs directly,  - '--set-string' to provide key=val forcing val to be stored as a string,  - '--set-file' to provide key=path to read a single large value from a file at path. To edit or append to the existing customized values, add the  '--reuse-values' flag, otherwise any existing customized values are ignored. If no chart value arguments are provided on the command line, any existing customized values are carried forward. If you want to revert to just the values provided in the chart, use the '--reset-values' flag. You can specify any of the chart value flags multiple times. The priority will be given to the last (right-most) value specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence: 	$ helm upgrade -f myvalues.yaml -f override.yaml redis ./redis Note that the key name provided to the '--set', '--set-string' and '--set-file' flags can reference structure elements. Examples:   - mybool=TRUE   - livenessProbe.timeoutSeconds=10   - metrics.annotations[0]=hey,metrics.annotations[1]=ho which sets the top level key mybool to true, the nested timeoutSeconds to 10, and two array values, respectively. Note that the value side of the key=val provided to '--set' and '--set-string' flags will pass through shell evaluation followed by yaml type parsing to produce the final value. This may alter inputs with special characters in unexpected ways, for example 	$ helm upgrade --set pwd=3jk$o2,z=f\30.e redis ./redis results in "pwd: 3jk" and "z: f30.e". Use single quotes to avoid shell evaluation and argument delimiters, and use backslash to escape yaml special characters: 	$ helm upgrade --set pwd='3jk$o2z=f\\30.e' redis ./redis which results in the expected "pwd: 3jk$o2z=f\30.e". If a single quote occurs in your value then follow your shell convention for escaping it; for example in bash: 	$ helm upgrade --set pwd='3jk$o2z=f\\30with'\''quote' which results in "pwd: 3jk$o2z=f\30with'quote".</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmUpgradeSettings.Chart"/></li>
    ///     <li><c>&lt;release&gt;</c> via <see cref="HelmUpgradeSettings.Release"/></li>
    ///     <li><c>--atomic</c> via <see cref="HelmUpgradeSettings.Atomic"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmUpgradeSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmUpgradeSettings.CertFile"/></li>
    ///     <li><c>--create-namespace</c> via <see cref="HelmUpgradeSettings.CreateNamespace"/></li>
    ///     <li><c>--description</c> via <see cref="HelmUpgradeSettings.Description"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmUpgradeSettings.Devel"/></li>
    ///     <li><c>--dry-run</c> via <see cref="HelmUpgradeSettings.DryRun"/></li>
    ///     <li><c>--force</c> via <see cref="HelmUpgradeSettings.Force"/></li>
    ///     <li><c>--help</c> via <see cref="HelmUpgradeSettings.Help"/></li>
    ///     <li><c>--install</c> via <see cref="HelmUpgradeSettings.Install"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmUpgradeSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmUpgradeSettings.Keyring"/></li>
    ///     <li><c>--namespace</c> via <see cref="HelmUpgradeSettings.Namespace"/></li>
    ///     <li><c>--no-hooks</c> via <see cref="HelmUpgradeSettings.NoHooks"/></li>
    ///     <li><c>--password</c> via <see cref="HelmUpgradeSettings.Password"/></li>
    ///     <li><c>--recreate-pods</c> via <see cref="HelmUpgradeSettings.RecreatePods"/></li>
    ///     <li><c>--render-subchart-notes</c> via <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmUpgradeSettings.Repo"/></li>
    ///     <li><c>--reset-values</c> via <see cref="HelmUpgradeSettings.ResetValues"/></li>
    ///     <li><c>--reuse-values</c> via <see cref="HelmUpgradeSettings.ReuseValues"/></li>
    ///     <li><c>--set</c> via <see cref="HelmUpgradeSettings.Set"/></li>
    ///     <li><c>--set-file</c> via <see cref="HelmUpgradeSettings.SetFile"/></li>
    ///     <li><c>--set-string</c> via <see cref="HelmUpgradeSettings.SetString"/></li>
    ///     <li><c>--timeout</c> via <see cref="HelmUpgradeSettings.Timeout"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmUpgradeSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmUpgradeSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmUpgradeSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmUpgradeSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmUpgradeSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmUpgradeSettings.TlsVerify"/></li>
    ///     <li><c>--username</c> via <see cref="HelmUpgradeSettings.Username"/></li>
    ///     <li><c>--values</c> via <see cref="HelmUpgradeSettings.Values"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmUpgradeSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmUpgradeSettings.Version"/></li>
    ///     <li><c>--wait</c> via <see cref="HelmUpgradeSettings.Wait"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmUpgrade(Configure<HelmUpgradeSettings> configurator)
    {
        return HelmUpgrade(configurator(new HelmUpgradeSettings()));
    }
    /// <summary>
    ///   <p>This command upgrades a release to a specified version of a chart and/or updates chart values. Required arguments are release and chart. The chart argument can be one of:  - a chart reference('stable/mariadb'); use '--version' and '--devel' flags for versions other than latest,  - a path to a chart directory,  - a packaged chart,  - a fully qualified URL. To customize the chart values, use any of  - '--values'/'-f' to pass in a yaml file holding settings,  - '--set' to provide one or more key=val pairs directly,  - '--set-string' to provide key=val forcing val to be stored as a string,  - '--set-file' to provide key=path to read a single large value from a file at path. To edit or append to the existing customized values, add the  '--reuse-values' flag, otherwise any existing customized values are ignored. If no chart value arguments are provided on the command line, any existing customized values are carried forward. If you want to revert to just the values provided in the chart, use the '--reset-values' flag. You can specify any of the chart value flags multiple times. The priority will be given to the last (right-most) value specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence: 	$ helm upgrade -f myvalues.yaml -f override.yaml redis ./redis Note that the key name provided to the '--set', '--set-string' and '--set-file' flags can reference structure elements. Examples:   - mybool=TRUE   - livenessProbe.timeoutSeconds=10   - metrics.annotations[0]=hey,metrics.annotations[1]=ho which sets the top level key mybool to true, the nested timeoutSeconds to 10, and two array values, respectively. Note that the value side of the key=val provided to '--set' and '--set-string' flags will pass through shell evaluation followed by yaml type parsing to produce the final value. This may alter inputs with special characters in unexpected ways, for example 	$ helm upgrade --set pwd=3jk$o2,z=f\30.e redis ./redis results in "pwd: 3jk" and "z: f30.e". Use single quotes to avoid shell evaluation and argument delimiters, and use backslash to escape yaml special characters: 	$ helm upgrade --set pwd='3jk$o2z=f\\30.e' redis ./redis which results in the expected "pwd: 3jk$o2z=f\30.e". If a single quote occurs in your value then follow your shell convention for escaping it; for example in bash: 	$ helm upgrade --set pwd='3jk$o2z=f\\30with'\''quote' which results in "pwd: 3jk$o2z=f\30with'quote".</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmUpgradeSettings.Chart"/></li>
    ///     <li><c>&lt;release&gt;</c> via <see cref="HelmUpgradeSettings.Release"/></li>
    ///     <li><c>--atomic</c> via <see cref="HelmUpgradeSettings.Atomic"/></li>
    ///     <li><c>--ca-file</c> via <see cref="HelmUpgradeSettings.CaFile"/></li>
    ///     <li><c>--cert-file</c> via <see cref="HelmUpgradeSettings.CertFile"/></li>
    ///     <li><c>--create-namespace</c> via <see cref="HelmUpgradeSettings.CreateNamespace"/></li>
    ///     <li><c>--description</c> via <see cref="HelmUpgradeSettings.Description"/></li>
    ///     <li><c>--devel</c> via <see cref="HelmUpgradeSettings.Devel"/></li>
    ///     <li><c>--dry-run</c> via <see cref="HelmUpgradeSettings.DryRun"/></li>
    ///     <li><c>--force</c> via <see cref="HelmUpgradeSettings.Force"/></li>
    ///     <li><c>--help</c> via <see cref="HelmUpgradeSettings.Help"/></li>
    ///     <li><c>--install</c> via <see cref="HelmUpgradeSettings.Install"/></li>
    ///     <li><c>--key-file</c> via <see cref="HelmUpgradeSettings.KeyFile"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmUpgradeSettings.Keyring"/></li>
    ///     <li><c>--namespace</c> via <see cref="HelmUpgradeSettings.Namespace"/></li>
    ///     <li><c>--no-hooks</c> via <see cref="HelmUpgradeSettings.NoHooks"/></li>
    ///     <li><c>--password</c> via <see cref="HelmUpgradeSettings.Password"/></li>
    ///     <li><c>--recreate-pods</c> via <see cref="HelmUpgradeSettings.RecreatePods"/></li>
    ///     <li><c>--render-subchart-notes</c> via <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></li>
    ///     <li><c>--repo</c> via <see cref="HelmUpgradeSettings.Repo"/></li>
    ///     <li><c>--reset-values</c> via <see cref="HelmUpgradeSettings.ResetValues"/></li>
    ///     <li><c>--reuse-values</c> via <see cref="HelmUpgradeSettings.ReuseValues"/></li>
    ///     <li><c>--set</c> via <see cref="HelmUpgradeSettings.Set"/></li>
    ///     <li><c>--set-file</c> via <see cref="HelmUpgradeSettings.SetFile"/></li>
    ///     <li><c>--set-string</c> via <see cref="HelmUpgradeSettings.SetString"/></li>
    ///     <li><c>--timeout</c> via <see cref="HelmUpgradeSettings.Timeout"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmUpgradeSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmUpgradeSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmUpgradeSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmUpgradeSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmUpgradeSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmUpgradeSettings.TlsVerify"/></li>
    ///     <li><c>--username</c> via <see cref="HelmUpgradeSettings.Username"/></li>
    ///     <li><c>--values</c> via <see cref="HelmUpgradeSettings.Values"/></li>
    ///     <li><c>--verify</c> via <see cref="HelmUpgradeSettings.Verify"/></li>
    ///     <li><c>--version</c> via <see cref="HelmUpgradeSettings.Version"/></li>
    ///     <li><c>--wait</c> via <see cref="HelmUpgradeSettings.Wait"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmUpgradeSettings Settings, IReadOnlyCollection<Output> Output)> HelmUpgrade(CombinatorialConfigure<HelmUpgradeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmUpgrade, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>Verify that the given chart has a valid provenance file. Provenance files provide crytographic verification that a chart has not been tampered with, and was packaged by a trusted provider. This command can be used to verify a local chart. Several other commands provide '--verify' flags that run the same validation. To generate a signed package, use the 'helm package --sign' command.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;path&gt;</c> via <see cref="HelmVerifySettings.Path"/></li>
    ///     <li><c>--help</c> via <see cref="HelmVerifySettings.Help"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmVerifySettings.Keyring"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmVerify(HelmVerifySettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmVerifySettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Verify that the given chart has a valid provenance file. Provenance files provide crytographic verification that a chart has not been tampered with, and was packaged by a trusted provider. This command can be used to verify a local chart. Several other commands provide '--verify' flags that run the same validation. To generate a signed package, use the 'helm package --sign' command.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;path&gt;</c> via <see cref="HelmVerifySettings.Path"/></li>
    ///     <li><c>--help</c> via <see cref="HelmVerifySettings.Help"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmVerifySettings.Keyring"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmVerify(Configure<HelmVerifySettings> configurator)
    {
        return HelmVerify(configurator(new HelmVerifySettings()));
    }
    /// <summary>
    ///   <p>Verify that the given chart has a valid provenance file. Provenance files provide crytographic verification that a chart has not been tampered with, and was packaged by a trusted provider. This command can be used to verify a local chart. Several other commands provide '--verify' flags that run the same validation. To generate a signed package, use the 'helm package --sign' command.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>&lt;path&gt;</c> via <see cref="HelmVerifySettings.Path"/></li>
    ///     <li><c>--help</c> via <see cref="HelmVerifySettings.Help"/></li>
    ///     <li><c>--keyring</c> via <see cref="HelmVerifySettings.Keyring"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmVerifySettings Settings, IReadOnlyCollection<Output> Output)> HelmVerify(CombinatorialConfigure<HelmVerifySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmVerify, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
    /// <summary>
    ///   <p>Show the client and server versions for Helm and tiller. This will print a representation of the client and server versions of Helm and Tiller. The output will look something like this: Client: &amp;version.Version{SemVer:"v2.0.0", GitCommit:"ff52399e51bb880526e9cd0ed8386f6433b74da1", GitTreeState:"clean"} Server: &amp;version.Version{SemVer:"v2.0.0", GitCommit:"b0c113dfb9f612a9add796549da66c0d294508a3", GitTreeState:"clean"} - SemVer is the semantic version of the release. - GitCommit is the SHA for the commit that this version was built from. - GitTreeState is "clean" if there are no local code changes when this binary was   built, and "dirty" if the binary was built from locally modified code. To print just the client version, use '--client'. To print just the server version, use '--server'.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--client</c> via <see cref="HelmVersionSettings.Client"/></li>
    ///     <li><c>--help</c> via <see cref="HelmVersionSettings.Help"/></li>
    ///     <li><c>--server</c> via <see cref="HelmVersionSettings.Server"/></li>
    ///     <li><c>--short</c> via <see cref="HelmVersionSettings.Short"/></li>
    ///     <li><c>--template</c> via <see cref="HelmVersionSettings.Template"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmVersionSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmVersionSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmVersionSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmVersionSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmVersionSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmVersionSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmVersion(HelmVersionSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new HelmVersionSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>Show the client and server versions for Helm and tiller. This will print a representation of the client and server versions of Helm and Tiller. The output will look something like this: Client: &amp;version.Version{SemVer:"v2.0.0", GitCommit:"ff52399e51bb880526e9cd0ed8386f6433b74da1", GitTreeState:"clean"} Server: &amp;version.Version{SemVer:"v2.0.0", GitCommit:"b0c113dfb9f612a9add796549da66c0d294508a3", GitTreeState:"clean"} - SemVer is the semantic version of the release. - GitCommit is the SHA for the commit that this version was built from. - GitTreeState is "clean" if there are no local code changes when this binary was   built, and "dirty" if the binary was built from locally modified code. To print just the client version, use '--client'. To print just the server version, use '--server'.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--client</c> via <see cref="HelmVersionSettings.Client"/></li>
    ///     <li><c>--help</c> via <see cref="HelmVersionSettings.Help"/></li>
    ///     <li><c>--server</c> via <see cref="HelmVersionSettings.Server"/></li>
    ///     <li><c>--short</c> via <see cref="HelmVersionSettings.Short"/></li>
    ///     <li><c>--template</c> via <see cref="HelmVersionSettings.Template"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmVersionSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmVersionSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmVersionSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmVersionSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmVersionSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmVersionSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> HelmVersion(Configure<HelmVersionSettings> configurator)
    {
        return HelmVersion(configurator(new HelmVersionSettings()));
    }
    /// <summary>
    ///   <p>Show the client and server versions for Helm and tiller. This will print a representation of the client and server versions of Helm and Tiller. The output will look something like this: Client: &amp;version.Version{SemVer:"v2.0.0", GitCommit:"ff52399e51bb880526e9cd0ed8386f6433b74da1", GitTreeState:"clean"} Server: &amp;version.Version{SemVer:"v2.0.0", GitCommit:"b0c113dfb9f612a9add796549da66c0d294508a3", GitTreeState:"clean"} - SemVer is the semantic version of the release. - GitCommit is the SHA for the commit that this version was built from. - GitTreeState is "clean" if there are no local code changes when this binary was   built, and "dirty" if the binary was built from locally modified code. To print just the client version, use '--client'. To print just the server version, use '--server'.</p>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--client</c> via <see cref="HelmVersionSettings.Client"/></li>
    ///     <li><c>--help</c> via <see cref="HelmVersionSettings.Help"/></li>
    ///     <li><c>--server</c> via <see cref="HelmVersionSettings.Server"/></li>
    ///     <li><c>--short</c> via <see cref="HelmVersionSettings.Short"/></li>
    ///     <li><c>--template</c> via <see cref="HelmVersionSettings.Template"/></li>
    ///     <li><c>--tls</c> via <see cref="HelmVersionSettings.Tls"/></li>
    ///     <li><c>--tls-ca-cert</c> via <see cref="HelmVersionSettings.TlsCaCert"/></li>
    ///     <li><c>--tls-cert</c> via <see cref="HelmVersionSettings.TlsCert"/></li>
    ///     <li><c>--tls-hostname</c> via <see cref="HelmVersionSettings.TlsHostname"/></li>
    ///     <li><c>--tls-key</c> via <see cref="HelmVersionSettings.TlsKey"/></li>
    ///     <li><c>--tls-verify</c> via <see cref="HelmVersionSettings.TlsVerify"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(HelmVersionSettings Settings, IReadOnlyCollection<Output> Output)> HelmVersion(CombinatorialConfigure<HelmVersionSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(HelmVersion, HelmLogger, degreeOfParallelism, completeOnFailure);
    }
}
#region HelmCompletionSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmCompletionSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for completion.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    public virtual string Shell { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("completion")
          .Add("--help", Help)
          .Add("{value}", Shell);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmCreateSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmCreateSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for create.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   The named Helm starter scaffold.
    /// </summary>
    public virtual string Starter { get; internal set; }
    /// <summary>
    ///   The name of chart directory to create.
    /// </summary>
    public virtual string Name { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("create")
          .Add("--help", Help)
          .Add("--starter {value}", Starter)
          .Add("{value}", Name);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmDeleteSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmDeleteSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Specify a description for the release.
    /// </summary>
    public virtual string Description { get; internal set; }
    /// <summary>
    ///   Simulate a delete.
    /// </summary>
    public virtual bool? DryRun { get; internal set; }
    /// <summary>
    ///   Help for delete.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Prevent hooks from running during deletion.
    /// </summary>
    public virtual bool? NoHooks { get; internal set; }
    /// <summary>
    ///   Remove the release from the store and make its name free for later use.
    /// </summary>
    public virtual bool? Purge { get; internal set; }
    /// <summary>
    ///   Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).
    /// </summary>
    public virtual long? Timeout { get; internal set; }
    /// <summary>
    ///   Enable TLS for request.
    /// </summary>
    public virtual bool? Tls { get; internal set; }
    /// <summary>
    ///   Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").
    /// </summary>
    public virtual string TlsCaCert { get; internal set; }
    /// <summary>
    ///   Path to TLS certificate file (default "$HELM_HOME/cert.pem").
    /// </summary>
    public virtual string TlsCert { get; internal set; }
    /// <summary>
    ///   The server name used to verify the hostname on the returned certificates from the server.
    /// </summary>
    public virtual string TlsHostname { get; internal set; }
    /// <summary>
    ///   Path to TLS key file (default "$HELM_HOME/key.pem").
    /// </summary>
    public virtual string TlsKey { get; internal set; }
    /// <summary>
    ///   Enable TLS for request and verify remote.
    /// </summary>
    public virtual bool? TlsVerify { get; internal set; }
    /// <summary>
    ///   The name of the releases to delete.
    /// </summary>
    public virtual IReadOnlyList<string> ReleaseNames => ReleaseNamesInternal.AsReadOnly();
    internal List<string> ReleaseNamesInternal { get; set; } = new List<string>();
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("delete")
          .Add("--description {value}", Description)
          .Add("--dry-run", DryRun)
          .Add("--help", Help)
          .Add("--no-hooks", NoHooks)
          .Add("--purge", Purge)
          .Add("--timeout {value}s", Timeout)
          .Add("--tls", Tls)
          .Add("--tls-ca-cert {value}", TlsCaCert)
          .Add("--tls-cert {value}", TlsCert)
          .Add("--tls-hostname {value}", TlsHostname)
          .Add("--tls-key {value}", TlsKey)
          .Add("--tls-verify", TlsVerify)
          .Add("{value}", ReleaseNames, separator: ' ');
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmDependencyBuildSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmDependencyBuildSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for build.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Keyring containing public keys (default "~/.gnupg/pubring.gpg").
    /// </summary>
    public virtual string Keyring { get; internal set; }
    /// <summary>
    ///   Verify the packages against signatures.
    /// </summary>
    public virtual bool? Verify { get; internal set; }
    /// <summary>
    ///   The name of the chart to build.
    /// </summary>
    public virtual string Chart { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("dependency build")
          .Add("--help", Help)
          .Add("--keyring {value}", Keyring)
          .Add("--verify", Verify)
          .Add("{value}", Chart);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmDependencyListSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmDependencyListSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for list.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   The name of the chart to list.
    /// </summary>
    public virtual string Chart { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("dependency list")
          .Add("--help", Help)
          .Add("{value}", Chart);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmDependencyUpdateSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmDependencyUpdateSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for update.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Keyring containing public keys (default "~/.gnupg/pubring.gpg").
    /// </summary>
    public virtual string Keyring { get; internal set; }
    /// <summary>
    ///   Do not refresh the local repository cache.
    /// </summary>
    public virtual bool? SkipRefresh { get; internal set; }
    /// <summary>
    ///   Verify the packages against signatures.
    /// </summary>
    public virtual bool? Verify { get; internal set; }
    /// <summary>
    ///   The name of the chart to update.
    /// </summary>
    public virtual string Chart { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("dependency update")
          .Add("--help", Help)
          .Add("--keyring {value}", Keyring)
          .Add("--skip-refresh", SkipRefresh)
          .Add("--verify", Verify)
          .Add("{value}", Chart);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmFetchSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmFetchSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
    /// </summary>
    public virtual string CaFile { get; internal set; }
    /// <summary>
    ///   Identify HTTPS client using this SSL certificate file.
    /// </summary>
    public virtual string CertFile { get; internal set; }
    /// <summary>
    ///   Location to write the chart. If this and tardir are specified, tardir is appended to this (default ".").
    /// </summary>
    public virtual string Destination { get; internal set; }
    /// <summary>
    ///   Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.
    /// </summary>
    public virtual bool? Devel { get; internal set; }
    /// <summary>
    ///   Help for fetch.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Identify HTTPS client using this SSL key file.
    /// </summary>
    public virtual string KeyFile { get; internal set; }
    /// <summary>
    ///   Keyring containing public keys (default "~/.gnupg/pubring.gpg").
    /// </summary>
    public virtual string Keyring { get; internal set; }
    /// <summary>
    ///   Chart repository password.
    /// </summary>
    public virtual string Password { get; internal set; }
    /// <summary>
    ///   Fetch the provenance file, but don't perform verification.
    /// </summary>
    public virtual bool? Prov { get; internal set; }
    /// <summary>
    ///   Chart repository url where to locate the requested chart.
    /// </summary>
    public virtual string Repo { get; internal set; }
    /// <summary>
    ///   If set to true, will untar the chart after downloading it.
    /// </summary>
    public virtual bool? Untar { get; internal set; }
    /// <summary>
    ///   If untar is specified, this flag specifies the name of the directory into which the chart is expanded (default ".").
    /// </summary>
    public virtual string Untardir { get; internal set; }
    /// <summary>
    ///   Chart repository username.
    /// </summary>
    public virtual string Username { get; internal set; }
    /// <summary>
    ///   Verify the package against its signature.
    /// </summary>
    public virtual bool? Verify { get; internal set; }
    /// <summary>
    ///   Specific version of a chart. Without this, the latest version is fetched.
    /// </summary>
    public virtual string Version { get; internal set; }
    /// <summary>
    ///   The charts to fetch. Can either be specified by <c>repoName/chartName</c> or directly by an url.
    /// </summary>
    public virtual IReadOnlyList<string> Charts => ChartsInternal.AsReadOnly();
    internal List<string> ChartsInternal { get; set; } = new List<string>();
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("fetch")
          .Add("--ca-file {value}", CaFile)
          .Add("--cert-file {value}", CertFile)
          .Add("--destination {value}", Destination)
          .Add("--devel", Devel)
          .Add("--help", Help)
          .Add("--key-file {value}", KeyFile)
          .Add("--keyring {value}", Keyring)
          .Add("--password {value}", Password, secret: true)
          .Add("--prov", Prov)
          .Add("--repo {value}", Repo)
          .Add("--untar", Untar)
          .Add("--untardir {value}", Untardir)
          .Add("--username {value}", Username)
          .Add("--verify", Verify)
          .Add("--version {value}", Version)
          .Add("{value}", Charts, separator: ' ');
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmGetSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmGetSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for get.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Get the named release with revision.
    /// </summary>
    public virtual int? Revision { get; internal set; }
    /// <summary>
    ///   Enable TLS for request.
    /// </summary>
    public virtual bool? Tls { get; internal set; }
    /// <summary>
    ///   Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").
    /// </summary>
    public virtual string TlsCaCert { get; internal set; }
    /// <summary>
    ///   Path to TLS certificate file (default "$HELM_HOME/cert.pem").
    /// </summary>
    public virtual string TlsCert { get; internal set; }
    /// <summary>
    ///   The server name used to verify the hostname on the returned certificates from the server.
    /// </summary>
    public virtual string TlsHostname { get; internal set; }
    /// <summary>
    ///   Path to TLS key file (default "$HELM_HOME/key.pem").
    /// </summary>
    public virtual string TlsKey { get; internal set; }
    /// <summary>
    ///   Enable TLS for request and verify remote.
    /// </summary>
    public virtual bool? TlsVerify { get; internal set; }
    /// <summary>
    ///   The name of the release to get.
    /// </summary>
    public virtual string ReleaseName { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("get")
          .Add("--help", Help)
          .Add("--revision {value}", Revision)
          .Add("--tls", Tls)
          .Add("--tls-ca-cert {value}", TlsCaCert)
          .Add("--tls-cert {value}", TlsCert)
          .Add("--tls-hostname {value}", TlsHostname)
          .Add("--tls-key {value}", TlsKey)
          .Add("--tls-verify", TlsVerify)
          .Add("{value}", ReleaseName);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmGetHooksSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmGetHooksSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for hooks.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Get the named release with revision.
    /// </summary>
    public virtual int? Revision { get; internal set; }
    /// <summary>
    ///   Enable TLS for request.
    /// </summary>
    public virtual bool? Tls { get; internal set; }
    /// <summary>
    ///   Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").
    /// </summary>
    public virtual string TlsCaCert { get; internal set; }
    /// <summary>
    ///   Path to TLS certificate file (default "$HELM_HOME/cert.pem").
    /// </summary>
    public virtual string TlsCert { get; internal set; }
    /// <summary>
    ///   The server name used to verify the hostname on the returned certificates from the server.
    /// </summary>
    public virtual string TlsHostname { get; internal set; }
    /// <summary>
    ///   Path to TLS key file (default "$HELM_HOME/key.pem").
    /// </summary>
    public virtual string TlsKey { get; internal set; }
    /// <summary>
    ///   Enable TLS for request and verify remote.
    /// </summary>
    public virtual bool? TlsVerify { get; internal set; }
    /// <summary>
    ///   The name of the release to get the hooks for.
    /// </summary>
    public virtual string ReleaseName { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("get hooks")
          .Add("--help", Help)
          .Add("--revision {value}", Revision)
          .Add("--tls", Tls)
          .Add("--tls-ca-cert {value}", TlsCaCert)
          .Add("--tls-cert {value}", TlsCert)
          .Add("--tls-hostname {value}", TlsHostname)
          .Add("--tls-key {value}", TlsKey)
          .Add("--tls-verify", TlsVerify)
          .Add("{value}", ReleaseName);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmGetManifestSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmGetManifestSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for manifest.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Get the named release with revision.
    /// </summary>
    public virtual int? Revision { get; internal set; }
    /// <summary>
    ///   Enable TLS for request.
    /// </summary>
    public virtual bool? Tls { get; internal set; }
    /// <summary>
    ///   Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").
    /// </summary>
    public virtual string TlsCaCert { get; internal set; }
    /// <summary>
    ///   Path to TLS certificate file (default "$HELM_HOME/cert.pem").
    /// </summary>
    public virtual string TlsCert { get; internal set; }
    /// <summary>
    ///   The server name used to verify the hostname on the returned certificates from the server.
    /// </summary>
    public virtual string TlsHostname { get; internal set; }
    /// <summary>
    ///   Path to TLS key file (default "$HELM_HOME/key.pem").
    /// </summary>
    public virtual string TlsKey { get; internal set; }
    /// <summary>
    ///   Enable TLS for request and verify remote.
    /// </summary>
    public virtual bool? TlsVerify { get; internal set; }
    /// <summary>
    ///   The name of the release to get the manifest for.
    /// </summary>
    public virtual string ReleaseName { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("get manifest")
          .Add("--help", Help)
          .Add("--revision {value}", Revision)
          .Add("--tls", Tls)
          .Add("--tls-ca-cert {value}", TlsCaCert)
          .Add("--tls-cert {value}", TlsCert)
          .Add("--tls-hostname {value}", TlsHostname)
          .Add("--tls-key {value}", TlsKey)
          .Add("--tls-verify", TlsVerify)
          .Add("{value}", ReleaseName);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmGetNotesSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmGetNotesSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for notes.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Get the notes of the named release with revision.
    /// </summary>
    public virtual int? Revision { get; internal set; }
    /// <summary>
    ///   Enable TLS for request.
    /// </summary>
    public virtual bool? Tls { get; internal set; }
    /// <summary>
    ///   Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").
    /// </summary>
    public virtual string TlsCaCert { get; internal set; }
    /// <summary>
    ///   Path to TLS certificate file (default "$HELM_HOME/cert.pem").
    /// </summary>
    public virtual string TlsCert { get; internal set; }
    /// <summary>
    ///   The server name used to verify the hostname on the returned certificates from the server.
    /// </summary>
    public virtual string TlsHostname { get; internal set; }
    /// <summary>
    ///   Path to TLS key file (default "$HELM_HOME/key.pem").
    /// </summary>
    public virtual string TlsKey { get; internal set; }
    /// <summary>
    ///   Enable TLS for request and verify remote.
    /// </summary>
    public virtual bool? TlsVerify { get; internal set; }
    public virtual string ReleaseName { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("get notes")
          .Add("--help", Help)
          .Add("--revision {value}", Revision)
          .Add("--tls", Tls)
          .Add("--tls-ca-cert {value}", TlsCaCert)
          .Add("--tls-cert {value}", TlsCert)
          .Add("--tls-hostname {value}", TlsHostname)
          .Add("--tls-key {value}", TlsKey)
          .Add("--tls-verify", TlsVerify)
          .Add("{value}", ReleaseName);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmGetValuesSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmGetValuesSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Dump all (computed) values.
    /// </summary>
    public virtual bool? All { get; internal set; }
    /// <summary>
    ///   Help for values.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Output the specified format (json or yaml) (default "yaml").
    /// </summary>
    public virtual string Output { get; internal set; }
    /// <summary>
    ///   Get the named release with revision.
    /// </summary>
    public virtual int? Revision { get; internal set; }
    /// <summary>
    ///   Enable TLS for request.
    /// </summary>
    public virtual bool? Tls { get; internal set; }
    /// <summary>
    ///   Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").
    /// </summary>
    public virtual string TlsCaCert { get; internal set; }
    /// <summary>
    ///   Path to TLS certificate file (default "$HELM_HOME/cert.pem").
    /// </summary>
    public virtual string TlsCert { get; internal set; }
    /// <summary>
    ///   The server name used to verify the hostname on the returned certificates from the server.
    /// </summary>
    public virtual string TlsHostname { get; internal set; }
    /// <summary>
    ///   Path to TLS key file (default "$HELM_HOME/key.pem").
    /// </summary>
    public virtual string TlsKey { get; internal set; }
    /// <summary>
    ///   Enable TLS for request and verify remote.
    /// </summary>
    public virtual bool? TlsVerify { get; internal set; }
    /// <summary>
    ///   The name of the release to get the values for.
    /// </summary>
    public virtual string ReleaseName { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("get values")
          .Add("--all", All)
          .Add("--help", Help)
          .Add("--output {value}", Output)
          .Add("--revision {value}", Revision)
          .Add("--tls", Tls)
          .Add("--tls-ca-cert {value}", TlsCaCert)
          .Add("--tls-cert {value}", TlsCert)
          .Add("--tls-hostname {value}", TlsHostname)
          .Add("--tls-key {value}", TlsKey)
          .Add("--tls-verify", TlsVerify)
          .Add("{value}", ReleaseName);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmHistorySettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmHistorySettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Specifies the max column width of output (default 60).
    /// </summary>
    public virtual uint? ColWidth { get; internal set; }
    /// <summary>
    ///   Help for history.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Maximum number of revision to include in history (default 256).
    /// </summary>
    public virtual int? Max { get; internal set; }
    /// <summary>
    ///   Prints the output in the specified format (json|table|yaml) (default "table").
    /// </summary>
    public virtual string Output { get; internal set; }
    /// <summary>
    ///   Enable TLS for request.
    /// </summary>
    public virtual bool? Tls { get; internal set; }
    /// <summary>
    ///   Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").
    /// </summary>
    public virtual string TlsCaCert { get; internal set; }
    /// <summary>
    ///   Path to TLS certificate file (default "$HELM_HOME/cert.pem").
    /// </summary>
    public virtual string TlsCert { get; internal set; }
    /// <summary>
    ///   The server name used to verify the hostname on the returned certificates from the server.
    /// </summary>
    public virtual string TlsHostname { get; internal set; }
    /// <summary>
    ///   Path to TLS key file (default "$HELM_HOME/key.pem").
    /// </summary>
    public virtual string TlsKey { get; internal set; }
    /// <summary>
    ///   Enable TLS for request and verify remote.
    /// </summary>
    public virtual bool? TlsVerify { get; internal set; }
    /// <summary>
    ///   The name of the release to get the history for.
    /// </summary>
    public virtual string ReleaseName { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("history")
          .Add("--col-width {value}", ColWidth)
          .Add("--help", Help)
          .Add("--max {value}", Max)
          .Add("--output {value}", Output)
          .Add("--tls", Tls)
          .Add("--tls-ca-cert {value}", TlsCaCert)
          .Add("--tls-cert {value}", TlsCert)
          .Add("--tls-hostname {value}", TlsHostname)
          .Add("--tls-key {value}", TlsKey)
          .Add("--tls-verify", TlsVerify)
          .Add("{value}", ReleaseName);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmHomeSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmHomeSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for home.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("home")
          .Add("--help", Help);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmInitSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmInitSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Auto-mount the given service account to tiller (default true).
    /// </summary>
    public virtual bool? AutomountServiceAccountToken { get; internal set; }
    /// <summary>
    ///   Use the canary Tiller image.
    /// </summary>
    public virtual bool? CanaryImage { get; internal set; }
    /// <summary>
    ///   If set does not install Tiller.
    /// </summary>
    public virtual bool? ClientOnly { get; internal set; }
    /// <summary>
    ///   Do not install local or remote.
    /// </summary>
    public virtual bool? DryRun { get; internal set; }
    /// <summary>
    ///   Force upgrade of Tiller to the current helm version.
    /// </summary>
    public virtual bool? ForceUpgrade { get; internal set; }
    /// <summary>
    ///   Help for init.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Limit the maximum number of revisions saved per release. Use 0 for no limit.
    /// </summary>
    public virtual long? HistoryMax { get; internal set; }
    /// <summary>
    ///   URL for local repository (default "http://127.0.0.1:8879/charts").
    /// </summary>
    public virtual string LocalRepoUrl { get; internal set; }
    /// <summary>
    ///   Install Tiller with net=host.
    /// </summary>
    public virtual bool? NetHost { get; internal set; }
    /// <summary>
    ///   Labels to specify the node on which Tiller is installed (app=tiller,helm=rocks).
    /// </summary>
    public virtual string NodeSelectors { get; internal set; }
    /// <summary>
    ///   Skip installation and output Tiller's manifest in specified format (json or yaml).
    /// </summary>
    public virtual HelmOutputFormat Output { get; internal set; }
    /// <summary>
    ///   Override values for the Tiller Deployment manifest (can specify multiple or separate values with commas: key1=val1,key2=val2).
    /// </summary>
    public virtual IReadOnlyDictionary<string, object> Override => OverrideInternal.AsReadOnly();
    internal Dictionary<string, object> OverrideInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    /// <summary>
    ///   Amount of tiller instances to run on the cluster (default 1).
    /// </summary>
    public virtual long? Replicas { get; internal set; }
    /// <summary>
    ///   Name of service account.
    /// </summary>
    public virtual string ServiceAccount { get; internal set; }
    /// <summary>
    ///   Do not refresh (download) the local repository cache.
    /// </summary>
    public virtual bool? SkipRefresh { get; internal set; }
    /// <summary>
    ///   URL for stable repository (default "https://kubernetes-charts.storage.googleapis.com").
    /// </summary>
    public virtual string StableRepoUrl { get; internal set; }
    /// <summary>
    ///   Override Tiller image.
    /// </summary>
    public virtual string TillerImage { get; internal set; }
    /// <summary>
    ///   Install Tiller with TLS enabled.
    /// </summary>
    public virtual bool? TillerTls { get; internal set; }
    /// <summary>
    ///   Path to TLS certificate file to install with Tiller.
    /// </summary>
    public virtual string TillerTlsCert { get; internal set; }
    /// <summary>
    ///   The server name used to verify the hostname on the returned certificates from Tiller.
    /// </summary>
    public virtual string TillerTlsHostname { get; internal set; }
    /// <summary>
    ///   Path to TLS key file to install with Tiller.
    /// </summary>
    public virtual string TillerTlsKey { get; internal set; }
    /// <summary>
    ///   Install Tiller with TLS enabled and to verify remote certificates.
    /// </summary>
    public virtual bool? TillerTlsVerify { get; internal set; }
    /// <summary>
    ///   Path to CA root certificate.
    /// </summary>
    public virtual string TlsCaCert { get; internal set; }
    /// <summary>
    ///   Upgrade if Tiller is already installed.
    /// </summary>
    public virtual bool? Upgrade { get; internal set; }
    /// <summary>
    ///   Block until Tiller is running and ready to receive requests.
    /// </summary>
    public virtual bool? Wait { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("init")
          .Add("--automount-service-account-token", AutomountServiceAccountToken)
          .Add("--canary-image", CanaryImage)
          .Add("--client-only", ClientOnly)
          .Add("--dry-run", DryRun)
          .Add("--force-upgrade", ForceUpgrade)
          .Add("--help", Help)
          .Add("--history-max {value}", HistoryMax)
          .Add("--local-repo-url {value}", LocalRepoUrl)
          .Add("--net-host", NetHost)
          .Add("--node-selectors {value}", NodeSelectors)
          .Add("--output {value}", Output)
          .Add("--override {value}", Override, "{key}={value}", separator: ',')
          .Add("--replicas {value}", Replicas)
          .Add("--service-account {value}", ServiceAccount)
          .Add("--skip-refresh", SkipRefresh)
          .Add("--stable-repo-url {value}", StableRepoUrl)
          .Add("--tiller-image {value}", TillerImage)
          .Add("--tiller-tls", TillerTls)
          .Add("--tiller-tls-cert {value}", TillerTlsCert)
          .Add("--tiller-tls-hostname {value}", TillerTlsHostname)
          .Add("--tiller-tls-key {value}", TillerTlsKey)
          .Add("--tiller-tls-verify", TillerTlsVerify)
          .Add("--tls-ca-cert {value}", TlsCaCert)
          .Add("--upgrade", Upgrade)
          .Add("--wait", Wait);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmInspectSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmInspectSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Chart repository url where to locate the requested chart.
    /// </summary>
    public virtual string CaFile { get; internal set; }
    /// <summary>
    ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
    /// </summary>
    public virtual string CertFile { get; internal set; }
    /// <summary>
    ///   Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.
    /// </summary>
    public virtual bool? Devel { get; internal set; }
    /// <summary>
    ///   Help for inspect.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Identify HTTPS client using this SSL key file.
    /// </summary>
    public virtual string KeyFile { get; internal set; }
    /// <summary>
    ///   Path to the keyring containing public verification keys (default "~/.gnupg/pubring.gpg").
    /// </summary>
    public virtual string Keyring { get; internal set; }
    /// <summary>
    ///   Chart repository password where to locate the requested chart.
    /// </summary>
    public virtual string Password { get; internal set; }
    /// <summary>
    ///   Chart repository url where to locate the requested chart.
    /// </summary>
    public virtual string Repo { get; internal set; }
    /// <summary>
    ///   Chart repository username where to locate the requested chart.
    /// </summary>
    public virtual string Username { get; internal set; }
    /// <summary>
    ///   Verify the provenance data for this chart.
    /// </summary>
    public virtual bool? Verify { get; internal set; }
    /// <summary>
    ///   Version of the chart. By default, the newest chart is shown.
    /// </summary>
    public virtual string Version { get; internal set; }
    /// <summary>
    ///   The name of the chart to inspect.
    /// </summary>
    public virtual string Chart { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("inspect")
          .Add("--ca-file {value}", CaFile)
          .Add("--cert-file {value}", CertFile)
          .Add("--devel", Devel)
          .Add("--help", Help)
          .Add("--key-file {value}", KeyFile)
          .Add("--keyring {value}", Keyring)
          .Add("--password {value}", Password, secret: true)
          .Add("--repo {value}", Repo)
          .Add("--username {value}", Username)
          .Add("--verify", Verify)
          .Add("--version {value}", Version)
          .Add("{value}", Chart);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmInspectChartSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmInspectChartSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Chart repository url where to locate the requested chart.
    /// </summary>
    public virtual string CaFile { get; internal set; }
    /// <summary>
    ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
    /// </summary>
    public virtual string CertFile { get; internal set; }
    /// <summary>
    ///   Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.
    /// </summary>
    public virtual bool? Devel { get; internal set; }
    /// <summary>
    ///   Help for chart.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Identify HTTPS client using this SSL key file.
    /// </summary>
    public virtual string KeyFile { get; internal set; }
    /// <summary>
    ///   Path to the keyring containing public verification keys (default "~/.gnupg/pubring.gpg").
    /// </summary>
    public virtual string Keyring { get; internal set; }
    /// <summary>
    ///   Chart repository password where to locate the requested chart.
    /// </summary>
    public virtual string Password { get; internal set; }
    /// <summary>
    ///   Chart repository url where to locate the requested chart.
    /// </summary>
    public virtual string Repo { get; internal set; }
    /// <summary>
    ///   Chart repository username where to locate the requested chart.
    /// </summary>
    public virtual string Username { get; internal set; }
    /// <summary>
    ///   Verify the provenance data for this chart.
    /// </summary>
    public virtual bool? Verify { get; internal set; }
    /// <summary>
    ///   Version of the chart. By default, the newest chart is shown.
    /// </summary>
    public virtual string Version { get; internal set; }
    /// <summary>
    ///   The name of the chart to inspect.
    /// </summary>
    public virtual string Chart { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("inspect chart")
          .Add("--ca-file {value}", CaFile)
          .Add("--cert-file {value}", CertFile)
          .Add("--devel", Devel)
          .Add("--help", Help)
          .Add("--key-file {value}", KeyFile)
          .Add("--keyring {value}", Keyring)
          .Add("--password {value}", Password, secret: true)
          .Add("--repo {value}", Repo)
          .Add("--username {value}", Username)
          .Add("--verify", Verify)
          .Add("--version {value}", Version)
          .Add("{value}", Chart);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmInspectReadmeSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmInspectReadmeSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Chart repository url where to locate the requested chart.
    /// </summary>
    public virtual string CaFile { get; internal set; }
    /// <summary>
    ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
    /// </summary>
    public virtual string CertFile { get; internal set; }
    /// <summary>
    ///   Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.
    /// </summary>
    public virtual bool? Devel { get; internal set; }
    /// <summary>
    ///   Help for readme.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Identify HTTPS client using this SSL key file.
    /// </summary>
    public virtual string KeyFile { get; internal set; }
    /// <summary>
    ///   Path to the keyring containing public verification keys (default "~/.gnupg/pubring.gpg").
    /// </summary>
    public virtual string Keyring { get; internal set; }
    /// <summary>
    ///   Chart repository url where to locate the requested chart.
    /// </summary>
    public virtual string Repo { get; internal set; }
    /// <summary>
    ///   Verify the provenance data for this chart.
    /// </summary>
    public virtual bool? Verify { get; internal set; }
    /// <summary>
    ///   Version of the chart. By default, the newest chart is shown.
    /// </summary>
    public virtual string Version { get; internal set; }
    /// <summary>
    ///   The name of the chart to inspect.
    /// </summary>
    public virtual string Chart { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("inspect readme")
          .Add("--ca-file {value}", CaFile)
          .Add("--cert-file {value}", CertFile)
          .Add("--devel", Devel)
          .Add("--help", Help)
          .Add("--key-file {value}", KeyFile)
          .Add("--keyring {value}", Keyring)
          .Add("--repo {value}", Repo)
          .Add("--verify", Verify)
          .Add("--version {value}", Version)
          .Add("{value}", Chart);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmInspectValuesSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmInspectValuesSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Chart repository url where to locate the requested chart.
    /// </summary>
    public virtual string CaFile { get; internal set; }
    /// <summary>
    ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
    /// </summary>
    public virtual string CertFile { get; internal set; }
    /// <summary>
    ///   Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.
    /// </summary>
    public virtual bool? Devel { get; internal set; }
    /// <summary>
    ///   Help for values.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Identify HTTPS client using this SSL key file.
    /// </summary>
    public virtual string KeyFile { get; internal set; }
    /// <summary>
    ///   Path to the keyring containing public verification keys (default "~/.gnupg/pubring.gpg").
    /// </summary>
    public virtual string Keyring { get; internal set; }
    /// <summary>
    ///   Chart repository password where to locate the requested chart.
    /// </summary>
    public virtual string Password { get; internal set; }
    /// <summary>
    ///   Chart repository url where to locate the requested chart.
    /// </summary>
    public virtual string Repo { get; internal set; }
    /// <summary>
    ///   Chart repository username where to locate the requested chart.
    /// </summary>
    public virtual string Username { get; internal set; }
    /// <summary>
    ///   Verify the provenance data for this chart.
    /// </summary>
    public virtual bool? Verify { get; internal set; }
    /// <summary>
    ///   Version of the chart. By default, the newest chart is shown.
    /// </summary>
    public virtual string Version { get; internal set; }
    /// <summary>
    ///   The name of the chart to inspect.
    /// </summary>
    public virtual string Chart { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("inspect values")
          .Add("--ca-file {value}", CaFile)
          .Add("--cert-file {value}", CertFile)
          .Add("--devel", Devel)
          .Add("--help", Help)
          .Add("--key-file {value}", KeyFile)
          .Add("--keyring {value}", Keyring)
          .Add("--password {value}", Password, secret: true)
          .Add("--repo {value}", Repo)
          .Add("--username {value}", Username)
          .Add("--verify", Verify)
          .Add("--version {value}", Version)
          .Add("{value}", Chart);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmInstallSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmInstallSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   If set, installation process purges chart on fail, also sets --wait flag.
    /// </summary>
    public virtual bool? Atomic { get; internal set; }
    /// <summary>
    ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
    /// </summary>
    public virtual string CaFile { get; internal set; }
    /// <summary>
    ///   Identify HTTPS client using this SSL certificate file.
    /// </summary>
    public virtual string CertFile { get; internal set; }
    /// <summary>
    ///   Run helm dependency update before installing the chart.
    /// </summary>
    public virtual bool? DepUp { get; internal set; }
    /// <summary>
    ///   Specify a description for the release.
    /// </summary>
    public virtual string Description { get; internal set; }
    /// <summary>
    ///   Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.
    /// </summary>
    public virtual bool? Devel { get; internal set; }
    /// <summary>
    ///   Simulate an install.
    /// </summary>
    public virtual bool? DryRun { get; internal set; }
    /// <summary>
    ///   Help for install.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Identify HTTPS client using this SSL key file.
    /// </summary>
    public virtual string KeyFile { get; internal set; }
    /// <summary>
    ///   Location of public keys used for verification (default "~/.gnupg/pubring.gpg").
    /// </summary>
    public virtual string Keyring { get; internal set; }
    /// <summary>
    ///   Release name. If unspecified, it will autogenerate one for you.
    /// </summary>
    public virtual string Name { get; internal set; }
    /// <summary>
    ///   Specify template used to name the release.
    /// </summary>
    public virtual string NameTemplate { get; internal set; }
    /// <summary>
    ///   Namespace to install the release into. Defaults to the current kube config namespace.
    /// </summary>
    public virtual string Namespace { get; internal set; }
    /// <summary>
    ///   Prevent CRD hooks from running, but run other hooks.
    /// </summary>
    public virtual bool? NoCrdHook { get; internal set; }
    /// <summary>
    ///   Prevent hooks from running during install.
    /// </summary>
    public virtual bool? NoHooks { get; internal set; }
    /// <summary>
    ///   Chart repository password where to locate the requested chart.
    /// </summary>
    public virtual string Password { get; internal set; }
    /// <summary>
    ///   Render subchart notes along with the parent.
    /// </summary>
    public virtual bool? RenderSubchartNotes { get; internal set; }
    /// <summary>
    ///   Re-use the given name, even if that name is already used. This is unsafe in production.
    /// </summary>
    public virtual bool? Replace { get; internal set; }
    /// <summary>
    ///   Chart repository url where to locate the requested chart.
    /// </summary>
    public virtual string Repo { get; internal set; }
    /// <summary>
    ///   Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).
    /// </summary>
    public virtual IReadOnlyDictionary<string, object> Set => SetInternal.AsReadOnly();
    internal Dictionary<string, object> SetInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    /// <summary>
    ///   Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).
    /// </summary>
    public virtual IReadOnlyDictionary<string, object> SetFile => SetFileInternal.AsReadOnly();
    internal Dictionary<string, object> SetFileInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    /// <summary>
    ///   Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).
    /// </summary>
    public virtual IReadOnlyDictionary<string, object> SetString => SetStringInternal.AsReadOnly();
    internal Dictionary<string, object> SetStringInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    /// <summary>
    ///   Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).
    /// </summary>
    public virtual long? Timeout { get; internal set; }
    /// <summary>
    ///   Enable TLS for request.
    /// </summary>
    public virtual bool? Tls { get; internal set; }
    /// <summary>
    ///   Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").
    /// </summary>
    public virtual string TlsCaCert { get; internal set; }
    /// <summary>
    ///   Path to TLS certificate file (default "$HELM_HOME/cert.pem").
    /// </summary>
    public virtual string TlsCert { get; internal set; }
    /// <summary>
    ///   The server name used to verify the hostname on the returned certificates from the server.
    /// </summary>
    public virtual string TlsHostname { get; internal set; }
    /// <summary>
    ///   Path to TLS key file (default "$HELM_HOME/key.pem").
    /// </summary>
    public virtual string TlsKey { get; internal set; }
    /// <summary>
    ///   Enable TLS for request and verify remote.
    /// </summary>
    public virtual bool? TlsVerify { get; internal set; }
    /// <summary>
    ///   Chart repository username where to locate the requested chart.
    /// </summary>
    public virtual string Username { get; internal set; }
    /// <summary>
    ///   Specify values in a YAML file or a URL(can specify multiple) (default []).
    /// </summary>
    public virtual IReadOnlyList<string> Values => ValuesInternal.AsReadOnly();
    internal List<string> ValuesInternal { get; set; } = new List<string>();
    /// <summary>
    ///   Verify the package before installing it.
    /// </summary>
    public virtual bool? Verify { get; internal set; }
    /// <summary>
    ///   Specify the exact chart version to install. If this is not specified, the latest version is installed.
    /// </summary>
    public virtual string Version { get; internal set; }
    /// <summary>
    ///   If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.
    /// </summary>
    public virtual bool? Wait { get; internal set; }
    /// <summary>
    ///   The name of the chart to install.
    /// </summary>
    public virtual string Chart { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("install")
          .Add("--atomic", Atomic)
          .Add("--ca-file {value}", CaFile)
          .Add("--cert-file {value}", CertFile)
          .Add("--dep-up", DepUp)
          .Add("--description {value}", Description)
          .Add("--devel", Devel)
          .Add("--dry-run", DryRun)
          .Add("--help", Help)
          .Add("--key-file {value}", KeyFile)
          .Add("--keyring {value}", Keyring)
          .Add("--name {value}", Name)
          .Add("--name-template {value}", NameTemplate)
          .Add("--namespace {value}", Namespace)
          .Add("--no-crd-hook", NoCrdHook)
          .Add("--no-hooks", NoHooks)
          .Add("--password {value}", Password, secret: true)
          .Add("--render-subchart-notes", RenderSubchartNotes)
          .Add("--replace", Replace)
          .Add("--repo {value}", Repo)
          .Add("--set {value}", Set, "{key}={value}", separator: ',')
          .Add("--set-file {value}", SetFile, "{key}={value}", separator: ',')
          .Add("--set-string {value}", SetString, "{key}={value}", separator: ',')
          .Add("--timeout {value}s", Timeout)
          .Add("--tls", Tls)
          .Add("--tls-ca-cert {value}", TlsCaCert)
          .Add("--tls-cert {value}", TlsCert)
          .Add("--tls-hostname {value}", TlsHostname)
          .Add("--tls-key {value}", TlsKey)
          .Add("--tls-verify", TlsVerify)
          .Add("--username {value}", Username)
          .Add("--values {value}", Values)
          .Add("--verify", Verify)
          .Add("--version {value}", Version)
          .Add("--wait", Wait)
          .Add("{value}", Chart);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmLintSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmLintSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for lint.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Namespace to put the release into (default "default").
    /// </summary>
    public virtual string Namespace { get; internal set; }
    /// <summary>
    ///   Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).
    /// </summary>
    public virtual IReadOnlyDictionary<string, object> Set => SetInternal.AsReadOnly();
    internal Dictionary<string, object> SetInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    /// <summary>
    ///   Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).
    /// </summary>
    public virtual IReadOnlyDictionary<string, object> SetFile => SetFileInternal.AsReadOnly();
    internal Dictionary<string, object> SetFileInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    /// <summary>
    ///   Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).
    /// </summary>
    public virtual IReadOnlyDictionary<string, object> SetString => SetStringInternal.AsReadOnly();
    internal Dictionary<string, object> SetStringInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    /// <summary>
    ///   Fail on lint warnings.
    /// </summary>
    public virtual bool? Strict { get; internal set; }
    /// <summary>
    ///   Specify values in a YAML file (can specify multiple) (default []).
    /// </summary>
    public virtual IReadOnlyList<string> Values => ValuesInternal.AsReadOnly();
    internal List<string> ValuesInternal { get; set; } = new List<string>();
    /// <summary>
    ///   The Path to a chart.
    /// </summary>
    public virtual string Path { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("lint")
          .Add("--help", Help)
          .Add("--namespace {value}", Namespace)
          .Add("--set {value}", Set, "{key}={value}", separator: ',')
          .Add("--set-file {value}", SetFile, "{key}={value}", separator: ',')
          .Add("--set-string {value}", SetString, "{key}={value}", separator: ',')
          .Add("--strict", Strict)
          .Add("--values {value}", Values)
          .Add("{value}", Path);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmListSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmListSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Show all releases, not just the ones marked DEPLOYED.
    /// </summary>
    public virtual bool? All { get; internal set; }
    /// <summary>
    ///   Sort by chart name.
    /// </summary>
    public virtual bool? ChartName { get; internal set; }
    /// <summary>
    ///   Specifies the max column width of output (default 60).
    /// </summary>
    public virtual uint? ColWidth { get; internal set; }
    /// <summary>
    ///   Sort by release date.
    /// </summary>
    public virtual bool? Date { get; internal set; }
    /// <summary>
    ///   Show deleted releases.
    /// </summary>
    public virtual bool? Deleted { get; internal set; }
    /// <summary>
    ///   Show releases that are currently being deleted.
    /// </summary>
    public virtual bool? Deleting { get; internal set; }
    /// <summary>
    ///   Show deployed releases. If no other is specified, this will be automatically enabled.
    /// </summary>
    public virtual bool? Deployed { get; internal set; }
    /// <summary>
    ///   Show failed releases.
    /// </summary>
    public virtual bool? Failed { get; internal set; }
    /// <summary>
    ///   Help for list.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Maximum number of releases to fetch (default 256).
    /// </summary>
    public virtual long? Max { get; internal set; }
    /// <summary>
    ///   Show releases within a specific namespace.
    /// </summary>
    public virtual string Namespace { get; internal set; }
    /// <summary>
    ///   Next release name in the list, used to offset from start value.
    /// </summary>
    public virtual string Offset { get; internal set; }
    /// <summary>
    ///   Output the specified format (json or yaml).
    /// </summary>
    public virtual HelmOutputFormat Output { get; internal set; }
    /// <summary>
    ///   Show pending releases.
    /// </summary>
    public virtual bool? Pending { get; internal set; }
    /// <summary>
    ///   Reverse the sort order.
    /// </summary>
    public virtual bool? Reverse { get; internal set; }
    /// <summary>
    ///   Output short (quiet) listing format.
    /// </summary>
    public virtual bool? Short { get; internal set; }
    /// <summary>
    ///   Enable TLS for request.
    /// </summary>
    public virtual bool? Tls { get; internal set; }
    /// <summary>
    ///   Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").
    /// </summary>
    public virtual string TlsCaCert { get; internal set; }
    /// <summary>
    ///   Path to TLS certificate file (default "$HELM_HOME/cert.pem").
    /// </summary>
    public virtual string TlsCert { get; internal set; }
    /// <summary>
    ///   The server name used to verify the hostname on the returned certificates from the server.
    /// </summary>
    public virtual string TlsHostname { get; internal set; }
    /// <summary>
    ///   Path to TLS key file (default "$HELM_HOME/key.pem").
    /// </summary>
    public virtual string TlsKey { get; internal set; }
    /// <summary>
    ///   Enable TLS for request and verify remote.
    /// </summary>
    public virtual bool? TlsVerify { get; internal set; }
    /// <summary>
    ///   The filter to use.
    /// </summary>
    public virtual string Filter { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("list")
          .Add("--all", All)
          .Add("--chart-name", ChartName)
          .Add("--col-width {value}", ColWidth)
          .Add("--date", Date)
          .Add("--deleted", Deleted)
          .Add("--deleting", Deleting)
          .Add("--deployed", Deployed)
          .Add("--failed", Failed)
          .Add("--help", Help)
          .Add("--max {value}", Max)
          .Add("--namespace {value}", Namespace)
          .Add("--offset {value}", Offset)
          .Add("--output {value}", Output)
          .Add("--pending", Pending)
          .Add("--reverse", Reverse)
          .Add("--short", Short)
          .Add("--tls", Tls)
          .Add("--tls-ca-cert {value}", TlsCaCert)
          .Add("--tls-cert {value}", TlsCert)
          .Add("--tls-hostname {value}", TlsHostname)
          .Add("--tls-key {value}", TlsKey)
          .Add("--tls-verify", TlsVerify)
          .Add("{value}", Filter);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmPackageSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmPackageSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Set the appVersion on the chart to this version.
    /// </summary>
    public virtual string AppVersion { get; internal set; }
    /// <summary>
    ///   Update dependencies from "requirements.yaml" to dir "charts/" before packaging.
    /// </summary>
    public virtual bool? DependencyUpdate { get; internal set; }
    /// <summary>
    ///   Location to write the chart. (default ".").
    /// </summary>
    public virtual string Destination { get; internal set; }
    /// <summary>
    ///   Help for package.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Name of the key to use when signing. Used if --sign is true.
    /// </summary>
    public virtual string Key { get; internal set; }
    /// <summary>
    ///   Location of a public keyring (default "~/.gnupg/pubring.gpg").
    /// </summary>
    public virtual string Keyring { get; internal set; }
    /// <summary>
    ///   Save packaged chart to local chart repository (default true).
    /// </summary>
    public virtual bool? Save { get; internal set; }
    /// <summary>
    ///   Use a PGP private key to sign this package.
    /// </summary>
    public virtual bool? Sign { get; internal set; }
    /// <summary>
    ///   Set the version on the chart to this semver version.
    /// </summary>
    public virtual string Version { get; internal set; }
    /// <summary>
    ///   The paths to the charts to package.
    /// </summary>
    public virtual IReadOnlyList<string> ChartPaths => ChartPathsInternal.AsReadOnly();
    internal List<string> ChartPathsInternal { get; set; } = new List<string>();
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("package")
          .Add("--app-version {value}", AppVersion)
          .Add("--dependency-update", DependencyUpdate)
          .Add("--destination {value}", Destination)
          .Add("--help", Help)
          .Add("--key {value}", Key)
          .Add("--keyring {value}", Keyring)
          .Add("--save", Save)
          .Add("--sign", Sign)
          .Add("--version {value}", Version)
          .Add("{value}", ChartPaths, separator: ' ');
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmPluginInstallSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmPluginInstallSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for install.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Specify a version constraint. If this is not specified, the latest version is installed.
    /// </summary>
    public virtual string Version { get; internal set; }
    public virtual string Options { get; internal set; }
    /// <summary>
    ///   List of paths or urls of packages to install.
    /// </summary>
    public virtual IReadOnlyList<string> Paths => PathsInternal.AsReadOnly();
    internal List<string> PathsInternal { get; set; } = new List<string>();
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("plugin install")
          .Add("--help", Help)
          .Add("--version {value}", Version)
          .Add("{value}", Options)
          .Add("{value}", Paths, separator: ' ');
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmPluginListSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmPluginListSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for list.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("plugin list")
          .Add("--help", Help);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmPluginRemoveSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmPluginRemoveSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for remove.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   List of plugins to remove.
    /// </summary>
    public virtual IReadOnlyList<string> Plugins => PluginsInternal.AsReadOnly();
    internal List<string> PluginsInternal { get; set; } = new List<string>();
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("plugin remove")
          .Add("--help", Help)
          .Add("{value}", Plugins, separator: ' ');
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmPluginUpdateSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmPluginUpdateSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for update.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   List of plugins to update.
    /// </summary>
    public virtual IReadOnlyList<string> Plugins => PluginsInternal.AsReadOnly();
    internal List<string> PluginsInternal { get; set; } = new List<string>();
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("plugin update")
          .Add("--help", Help)
          .Add("{value}", Plugins, separator: ' ');
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmRepoAddSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmRepoAddSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
    /// </summary>
    public virtual string CaFile { get; internal set; }
    /// <summary>
    ///   Identify HTTPS client using this SSL certificate file.
    /// </summary>
    public virtual string CertFile { get; internal set; }
    /// <summary>
    ///   Help for add.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Identify HTTPS client using this SSL key file.
    /// </summary>
    public virtual string KeyFile { get; internal set; }
    /// <summary>
    ///   Raise error if repo is already registered.
    /// </summary>
    public virtual bool? NoUpdate { get; internal set; }
    /// <summary>
    ///   Chart repository password.
    /// </summary>
    public virtual string Password { get; internal set; }
    /// <summary>
    ///   Chart repository username.
    /// </summary>
    public virtual string Username { get; internal set; }
    /// <summary>
    ///   The name of the repository to add.
    /// </summary>
    public virtual string Name { get; internal set; }
    /// <summary>
    ///   The url of the repository to add.
    /// </summary>
    public virtual string Url { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("repo add")
          .Add("--ca-file {value}", CaFile)
          .Add("--cert-file {value}", CertFile)
          .Add("--help", Help)
          .Add("--key-file {value}", KeyFile)
          .Add("--no-update", NoUpdate)
          .Add("--password {value}", Password, secret: true)
          .Add("--username {value}", Username)
          .Add("{value}", Name)
          .Add("{value}", Url);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmRepoIndexSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmRepoIndexSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for index.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Merge the generated index into the given index.
    /// </summary>
    public virtual string Merge { get; internal set; }
    /// <summary>
    ///   Url of chart repository.
    /// </summary>
    public virtual string Url { get; internal set; }
    /// <summary>
    ///   The directory of the repository.
    /// </summary>
    public virtual string Directory { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("repo index")
          .Add("--help", Help)
          .Add("--merge {value}", Merge)
          .Add("--url {value}", Url)
          .Add("{value}", Directory);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmRepoListSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmRepoListSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for list.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("repo list")
          .Add("--help", Help);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmRepoRemoveSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmRepoRemoveSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for remove.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   The name of the repository.
    /// </summary>
    public virtual string Name { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("repo remove")
          .Add("--help", Help)
          .Add("{value}", Name);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmRepoUpdateSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmRepoUpdateSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for update.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Fail on update warnings.
    /// </summary>
    public virtual bool? Strict { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("repo update")
          .Add("--help", Help)
          .Add("--strict", Strict);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmResetSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmResetSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Forces Tiller uninstall even if there are releases installed, or if Tiller is not in ready state. Releases are not deleted.).
    /// </summary>
    public virtual bool? Force { get; internal set; }
    /// <summary>
    ///   Help for reset.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   If set deletes $HELM_HOME.
    /// </summary>
    public virtual bool? RemoveHelmHome { get; internal set; }
    /// <summary>
    ///   Enable TLS for request.
    /// </summary>
    public virtual bool? Tls { get; internal set; }
    /// <summary>
    ///   Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").
    /// </summary>
    public virtual string TlsCaCert { get; internal set; }
    /// <summary>
    ///   Path to TLS certificate file (default "$HELM_HOME/cert.pem").
    /// </summary>
    public virtual string TlsCert { get; internal set; }
    /// <summary>
    ///   The server name used to verify the hostname on the returned certificates from the server.
    /// </summary>
    public virtual string TlsHostname { get; internal set; }
    /// <summary>
    ///   Path to TLS key file (default "$HELM_HOME/key.pem").
    /// </summary>
    public virtual string TlsKey { get; internal set; }
    /// <summary>
    ///   Enable TLS for request and verify remote.
    /// </summary>
    public virtual bool? TlsVerify { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("reset")
          .Add("--force", Force)
          .Add("--help", Help)
          .Add("--remove-helm-home", RemoveHelmHome)
          .Add("--tls", Tls)
          .Add("--tls-ca-cert {value}", TlsCaCert)
          .Add("--tls-cert {value}", TlsCert)
          .Add("--tls-hostname {value}", TlsHostname)
          .Add("--tls-key {value}", TlsKey)
          .Add("--tls-verify", TlsVerify);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmRollbackSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmRollbackSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Specify a description for the release.
    /// </summary>
    public virtual string Description { get; internal set; }
    /// <summary>
    ///   Simulate a rollback.
    /// </summary>
    public virtual bool? DryRun { get; internal set; }
    /// <summary>
    ///   Force resource update through delete/recreate if needed.
    /// </summary>
    public virtual bool? Force { get; internal set; }
    /// <summary>
    ///   Help for rollback.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Prevent hooks from running during rollback.
    /// </summary>
    public virtual bool? NoHooks { get; internal set; }
    /// <summary>
    ///   Performs pods restart for the resource if applicable.
    /// </summary>
    public virtual bool? RecreatePods { get; internal set; }
    /// <summary>
    ///   Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).
    /// </summary>
    public virtual long? Timeout { get; internal set; }
    /// <summary>
    ///   Enable TLS for request.
    /// </summary>
    public virtual bool? Tls { get; internal set; }
    /// <summary>
    ///   Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").
    /// </summary>
    public virtual string TlsCaCert { get; internal set; }
    /// <summary>
    ///   Path to TLS certificate file (default "$HELM_HOME/cert.pem").
    /// </summary>
    public virtual string TlsCert { get; internal set; }
    /// <summary>
    ///   The server name used to verify the hostname on the returned certificates from the server.
    /// </summary>
    public virtual string TlsHostname { get; internal set; }
    /// <summary>
    ///   Path to TLS key file (default "$HELM_HOME/key.pem").
    /// </summary>
    public virtual string TlsKey { get; internal set; }
    /// <summary>
    ///   Enable TLS for request and verify remote.
    /// </summary>
    public virtual bool? TlsVerify { get; internal set; }
    /// <summary>
    ///   If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.
    /// </summary>
    public virtual bool? Wait { get; internal set; }
    /// <summary>
    ///   The name of the release.
    /// </summary>
    public virtual string Release { get; internal set; }
    /// <summary>
    ///   The revison to roll back.
    /// </summary>
    public virtual string Revision { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("rollback")
          .Add("--description {value}", Description)
          .Add("--dry-run", DryRun)
          .Add("--force", Force)
          .Add("--help", Help)
          .Add("--no-hooks", NoHooks)
          .Add("--recreate-pods", RecreatePods)
          .Add("--timeout {value}s", Timeout)
          .Add("--tls", Tls)
          .Add("--tls-ca-cert {value}", TlsCaCert)
          .Add("--tls-cert {value}", TlsCert)
          .Add("--tls-hostname {value}", TlsHostname)
          .Add("--tls-key {value}", TlsKey)
          .Add("--tls-verify", TlsVerify)
          .Add("--wait", Wait)
          .Add("{value}", Release)
          .Add("{value}", Revision);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmSearchSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmSearchSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Specifies the max column width of output (default 60).
    /// </summary>
    public virtual uint? ColWidth { get; internal set; }
    /// <summary>
    ///   Help for search.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Use regular expressions for searching.
    /// </summary>
    public virtual bool? Regexp { get; internal set; }
    /// <summary>
    ///   Search using semantic versioning constraints.
    /// </summary>
    public virtual string Version { get; internal set; }
    /// <summary>
    ///   Show the long listing, with each version of each chart on its own line.
    /// </summary>
    public virtual bool? Versions { get; internal set; }
    /// <summary>
    ///   The keyword to search for.
    /// </summary>
    public virtual string Keyword { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("search")
          .Add("--col-width {value}", ColWidth)
          .Add("--help", Help)
          .Add("--regexp", Regexp)
          .Add("--version {value}", Version)
          .Add("--versions", Versions)
          .Add("{value}", Keyword);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmServeSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmServeSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Address to listen on (default "127.0.0.1:8879").
    /// </summary>
    public virtual string Address { get; internal set; }
    /// <summary>
    ///   Help for serve.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Local directory path from which to serve charts.
    /// </summary>
    public virtual string RepoPath { get; internal set; }
    /// <summary>
    ///   External URL of chart repository.
    /// </summary>
    public virtual string Url { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("serve")
          .Add("--address {value}", Address)
          .Add("--help", Help)
          .Add("--repo-path {value}", RepoPath)
          .Add("--url {value}", Url);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmStatusSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmStatusSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for status.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Output the status in the specified format (json or yaml).
    /// </summary>
    public virtual HelmOutputFormat Output { get; internal set; }
    /// <summary>
    ///   If set, display the status of the named release with revision.
    /// </summary>
    public virtual int? Revision { get; internal set; }
    /// <summary>
    ///   Enable TLS for request.
    /// </summary>
    public virtual bool? Tls { get; internal set; }
    /// <summary>
    ///   Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").
    /// </summary>
    public virtual string TlsCaCert { get; internal set; }
    /// <summary>
    ///   Path to TLS certificate file (default "$HELM_HOME/cert.pem").
    /// </summary>
    public virtual string TlsCert { get; internal set; }
    /// <summary>
    ///   The server name used to verify the hostname on the returned certificates from the server.
    /// </summary>
    public virtual string TlsHostname { get; internal set; }
    /// <summary>
    ///   Path to TLS key file (default "$HELM_HOME/key.pem").
    /// </summary>
    public virtual string TlsKey { get; internal set; }
    /// <summary>
    ///   Enable TLS for request and verify remote.
    /// </summary>
    public virtual bool? TlsVerify { get; internal set; }
    /// <summary>
    ///   The name of the release to get the status for.
    /// </summary>
    public virtual string ReleaseName { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("status")
          .Add("--help", Help)
          .Add("--output {value}", Output)
          .Add("--revision {value}", Revision)
          .Add("--tls", Tls)
          .Add("--tls-ca-cert {value}", TlsCaCert)
          .Add("--tls-cert {value}", TlsCert)
          .Add("--tls-hostname {value}", TlsHostname)
          .Add("--tls-key {value}", TlsKey)
          .Add("--tls-verify", TlsVerify)
          .Add("{value}", ReleaseName);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmTemplateSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmTemplateSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Only execute the given templates.
    /// </summary>
    public virtual IReadOnlyDictionary<string, object> Execute => ExecuteInternal.AsReadOnly();
    internal Dictionary<string, object> ExecuteInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    /// <summary>
    ///   Help for template.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Set .Release.IsUpgrade instead of .Release.IsInstall.
    /// </summary>
    public virtual bool? IsUpgrade { get; internal set; }
    /// <summary>
    ///   Kubernetes version used as Capabilities.KubeVersion.Major/Minor (default "1.9").
    /// </summary>
    public virtual string KubeVersion { get; internal set; }
    /// <summary>
    ///   Release name (default "release-name").
    /// </summary>
    public virtual string Name { get; internal set; }
    /// <summary>
    ///   Specify template used to name the release.
    /// </summary>
    public virtual string NameTemplate { get; internal set; }
    /// <summary>
    ///   Namespace to install the release into.
    /// </summary>
    public virtual string Namespace { get; internal set; }
    /// <summary>
    ///   Show the computed NOTES.txt file as well.
    /// </summary>
    public virtual bool? Notes { get; internal set; }
    /// <summary>
    ///   Writes the executed templates to files in output-dir instead of stdout.
    /// </summary>
    public virtual string OutputDir { get; internal set; }
    /// <summary>
    ///   Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).
    /// </summary>
    public virtual IReadOnlyDictionary<string, object> Set => SetInternal.AsReadOnly();
    internal Dictionary<string, object> SetInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    /// <summary>
    ///   Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).
    /// </summary>
    public virtual IReadOnlyDictionary<string, object> SetFile => SetFileInternal.AsReadOnly();
    internal Dictionary<string, object> SetFileInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    /// <summary>
    ///   Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).
    /// </summary>
    public virtual IReadOnlyDictionary<string, object> SetString => SetStringInternal.AsReadOnly();
    internal Dictionary<string, object> SetStringInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    /// <summary>
    ///   Specify values in a YAML file (can specify multiple) (default []).
    /// </summary>
    public virtual IReadOnlyList<string> Values => ValuesInternal.AsReadOnly();
    internal List<string> ValuesInternal { get; set; } = new List<string>();
    public virtual string Chart { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("template")
          .Add("--execute {value}", Execute, "{key}={value}", separator: ',')
          .Add("--help", Help)
          .Add("--is-upgrade", IsUpgrade)
          .Add("--kube-version {value}", KubeVersion)
          .Add("--name {value}", Name)
          .Add("--name-template {value}", NameTemplate)
          .Add("--namespace {value}", Namespace)
          .Add("--notes", Notes)
          .Add("--output-dir {value}", OutputDir)
          .Add("--set {value}", Set, "{key}={value}", separator: ',')
          .Add("--set-file {value}", SetFile, "{key}={value}", separator: ',')
          .Add("--set-string {value}", SetString, "{key}={value}", separator: ',')
          .Add("--values {value}", Values)
          .Add("{value}", Chart);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmTestSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmTestSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Delete test pods upon completion.
    /// </summary>
    public virtual bool? Cleanup { get; internal set; }
    /// <summary>
    ///   Help for test.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Run test pods in parallel.
    /// </summary>
    public virtual bool? Parallel { get; internal set; }
    /// <summary>
    ///   Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).
    /// </summary>
    public virtual long? Timeout { get; internal set; }
    /// <summary>
    ///   Enable TLS for request.
    /// </summary>
    public virtual bool? Tls { get; internal set; }
    /// <summary>
    ///   Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").
    /// </summary>
    public virtual string TlsCaCert { get; internal set; }
    /// <summary>
    ///   Path to TLS certificate file (default "$HELM_HOME/cert.pem").
    /// </summary>
    public virtual string TlsCert { get; internal set; }
    /// <summary>
    ///   The server name used to verify the hostname on the returned certificates from the server.
    /// </summary>
    public virtual string TlsHostname { get; internal set; }
    /// <summary>
    ///   Path to TLS key file (default "$HELM_HOME/key.pem").
    /// </summary>
    public virtual string TlsKey { get; internal set; }
    /// <summary>
    ///   Enable TLS for request and verify remote.
    /// </summary>
    public virtual bool? TlsVerify { get; internal set; }
    /// <summary>
    ///   The name of the release to test.
    /// </summary>
    public virtual string Release { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("test")
          .Add("--cleanup", Cleanup)
          .Add("--help", Help)
          .Add("--parallel", Parallel)
          .Add("--timeout {value}s", Timeout)
          .Add("--tls", Tls)
          .Add("--tls-ca-cert {value}", TlsCaCert)
          .Add("--tls-cert {value}", TlsCert)
          .Add("--tls-hostname {value}", TlsHostname)
          .Add("--tls-key {value}", TlsKey)
          .Add("--tls-verify", TlsVerify)
          .Add("{value}", Release);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmUpgradeSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmUpgradeSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   If set, upgrade process rolls back changes made in case of failed upgrade, also sets --wait flag.
    /// </summary>
    public virtual bool? Atomic { get; internal set; }
    /// <summary>
    ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
    /// </summary>
    public virtual string CaFile { get; internal set; }
    /// <summary>
    ///   Identify HTTPS client using this SSL certificate file.
    /// </summary>
    public virtual string CertFile { get; internal set; }
    /// <summary>
    ///   Specify the description to use for the upgrade, rather than the default.
    /// </summary>
    public virtual string Description { get; internal set; }
    /// <summary>
    ///   Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.
    /// </summary>
    public virtual bool? Devel { get; internal set; }
    /// <summary>
    ///   Simulate an upgrade.
    /// </summary>
    public virtual bool? DryRun { get; internal set; }
    /// <summary>
    ///   Force resource update through delete/recreate if needed.
    /// </summary>
    public virtual bool? Force { get; internal set; }
    /// <summary>
    ///   Help for upgrade.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   If a release by this name doesn't already exist, run an install.
    /// </summary>
    public virtual bool? Install { get; internal set; }
    /// <summary>
    ///   If --install is set, create the release namespace if not present.
    /// </summary>
    public virtual bool? CreateNamespace { get; internal set; }
    /// <summary>
    ///   Identify HTTPS client using this SSL key file.
    /// </summary>
    public virtual string KeyFile { get; internal set; }
    /// <summary>
    ///   Path to the keyring that contains public signing keys (default "~/.gnupg/pubring.gpg").
    /// </summary>
    public virtual string Keyring { get; internal set; }
    /// <summary>
    ///   Namespace to install the release into (only used if --install is set). Defaults to the current kube config namespace.
    /// </summary>
    public virtual string Namespace { get; internal set; }
    /// <summary>
    ///   Disable pre/post upgrade hooks.
    /// </summary>
    public virtual bool? NoHooks { get; internal set; }
    /// <summary>
    ///   Chart repository password where to locate the requested chart.
    /// </summary>
    public virtual string Password { get; internal set; }
    /// <summary>
    ///   Performs pods restart for the resource if applicable.
    /// </summary>
    public virtual bool? RecreatePods { get; internal set; }
    /// <summary>
    ///   Render subchart notes along with parent.
    /// </summary>
    public virtual bool? RenderSubchartNotes { get; internal set; }
    /// <summary>
    ///   Chart repository url where to locate the requested chart.
    /// </summary>
    public virtual string Repo { get; internal set; }
    /// <summary>
    ///   When upgrading, reset the values to the ones built into the chart.
    /// </summary>
    public virtual bool? ResetValues { get; internal set; }
    /// <summary>
    ///   When upgrading, reuse the last release's values and merge in any overrides from the command line via --set and -f. If '--reset-values' is specified, this is ignored.
    /// </summary>
    public virtual bool? ReuseValues { get; internal set; }
    /// <summary>
    ///   Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).
    /// </summary>
    public virtual IReadOnlyDictionary<string, object> Set => SetInternal.AsReadOnly();
    internal Dictionary<string, object> SetInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    /// <summary>
    ///   Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).
    /// </summary>
    public virtual IReadOnlyDictionary<string, object> SetFile => SetFileInternal.AsReadOnly();
    internal Dictionary<string, object> SetFileInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    /// <summary>
    ///   Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).
    /// </summary>
    public virtual IReadOnlyDictionary<string, object> SetString => SetStringInternal.AsReadOnly();
    internal Dictionary<string, object> SetStringInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    /// <summary>
    ///   Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).
    /// </summary>
    public virtual long? Timeout { get; internal set; }
    /// <summary>
    ///   Enable TLS for request.
    /// </summary>
    public virtual bool? Tls { get; internal set; }
    /// <summary>
    ///   Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").
    /// </summary>
    public virtual string TlsCaCert { get; internal set; }
    /// <summary>
    ///   Path to TLS certificate file (default "$HELM_HOME/cert.pem").
    /// </summary>
    public virtual string TlsCert { get; internal set; }
    /// <summary>
    ///   The server name used to verify the hostname on the returned certificates from the server.
    /// </summary>
    public virtual string TlsHostname { get; internal set; }
    /// <summary>
    ///   Path to TLS key file (default "$HELM_HOME/key.pem").
    /// </summary>
    public virtual string TlsKey { get; internal set; }
    /// <summary>
    ///   Enable TLS for request and verify remote.
    /// </summary>
    public virtual bool? TlsVerify { get; internal set; }
    /// <summary>
    ///   Chart repository username where to locate the requested chart.
    /// </summary>
    public virtual string Username { get; internal set; }
    /// <summary>
    ///   Specify values in a YAML file or a URL(can specify multiple) (default []).
    /// </summary>
    public virtual IReadOnlyList<string> Values => ValuesInternal.AsReadOnly();
    internal List<string> ValuesInternal { get; set; } = new List<string>();
    /// <summary>
    ///   Verify the provenance of the chart before upgrading.
    /// </summary>
    public virtual bool? Verify { get; internal set; }
    /// <summary>
    ///   Specify the exact chart version to use. If this is not specified, the latest version is used.
    /// </summary>
    public virtual string Version { get; internal set; }
    /// <summary>
    ///   If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.
    /// </summary>
    public virtual bool? Wait { get; internal set; }
    /// <summary>
    ///   The name of the release to upgrade.
    /// </summary>
    public virtual string Release { get; internal set; }
    /// <summary>
    ///   The name of the chart to upgrade.
    /// </summary>
    public virtual string Chart { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("upgrade")
          .Add("--atomic", Atomic)
          .Add("--ca-file {value}", CaFile)
          .Add("--cert-file {value}", CertFile)
          .Add("--description {value}", Description)
          .Add("--devel", Devel)
          .Add("--dry-run", DryRun)
          .Add("--force", Force)
          .Add("--help", Help)
          .Add("--install", Install)
          .Add("--create-namespace", CreateNamespace)
          .Add("--key-file {value}", KeyFile)
          .Add("--keyring {value}", Keyring)
          .Add("--namespace {value}", Namespace)
          .Add("--no-hooks", NoHooks)
          .Add("--password {value}", Password, secret: true)
          .Add("--recreate-pods", RecreatePods)
          .Add("--render-subchart-notes", RenderSubchartNotes)
          .Add("--repo {value}", Repo)
          .Add("--reset-values", ResetValues)
          .Add("--reuse-values", ReuseValues)
          .Add("--set {value}", Set, "{key}={value}", separator: ',')
          .Add("--set-file {value}", SetFile, "{key}={value}", separator: ',')
          .Add("--set-string {value}", SetString, "{key}={value}", separator: ',')
          .Add("--timeout {value}s", Timeout)
          .Add("--tls", Tls)
          .Add("--tls-ca-cert {value}", TlsCaCert)
          .Add("--tls-cert {value}", TlsCert)
          .Add("--tls-hostname {value}", TlsHostname)
          .Add("--tls-key {value}", TlsKey)
          .Add("--tls-verify", TlsVerify)
          .Add("--username {value}", Username)
          .Add("--values {value}", Values)
          .Add("--verify", Verify)
          .Add("--version {value}", Version)
          .Add("--wait", Wait)
          .Add("{value}", Release)
          .Add("{value}", Chart);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmVerifySettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmVerifySettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Help for verify.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Keyring containing public keys (default "~/.gnupg/pubring.gpg").
    /// </summary>
    public virtual string Keyring { get; internal set; }
    /// <summary>
    ///   The path to the chart to verify.
    /// </summary>
    public virtual string Path { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("verify")
          .Add("--help", Help)
          .Add("--keyring {value}", Keyring)
          .Add("{value}", Path);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmVersionSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmVersionSettings : HelmToolSettings
{
    /// <summary>
    ///   Path to the Helm executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? HelmTasks.HelmLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? HelmTasks.HelmExitHandler;
    /// <summary>
    ///   Client version only.
    /// </summary>
    public virtual bool? Client { get; internal set; }
    /// <summary>
    ///   Help for version.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Server version only.
    /// </summary>
    public virtual bool? Server { get; internal set; }
    /// <summary>
    ///   Print the version number.
    /// </summary>
    public virtual bool? Short { get; internal set; }
    /// <summary>
    ///   Template for version string format.
    /// </summary>
    public virtual string Template { get; internal set; }
    /// <summary>
    ///   Enable TLS for request.
    /// </summary>
    public virtual bool? Tls { get; internal set; }
    /// <summary>
    ///   Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").
    /// </summary>
    public virtual string TlsCaCert { get; internal set; }
    /// <summary>
    ///   Path to TLS certificate file (default "$HELM_HOME/cert.pem").
    /// </summary>
    public virtual string TlsCert { get; internal set; }
    /// <summary>
    ///   The server name used to verify the hostname on the returned certificates from the server.
    /// </summary>
    public virtual string TlsHostname { get; internal set; }
    /// <summary>
    ///   Path to TLS key file (default "$HELM_HOME/key.pem").
    /// </summary>
    public virtual string TlsKey { get; internal set; }
    /// <summary>
    ///   Enable TLS for request and verify remote.
    /// </summary>
    public virtual bool? TlsVerify { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("version")
          .Add("--client", Client)
          .Add("--help", Help)
          .Add("--server", Server)
          .Add("--short", Short)
          .Add("--template {value}", Template)
          .Add("--tls", Tls)
          .Add("--tls-ca-cert {value}", TlsCaCert)
          .Add("--tls-cert {value}", TlsCert)
          .Add("--tls-hostname {value}", TlsHostname)
          .Add("--tls-key {value}", TlsKey)
          .Add("--tls-verify", TlsVerify);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmCommonSettings
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class HelmCommonSettings : ToolSettings
{
    /// <summary>
    ///   Enable verbose output.
    /// </summary>
    public virtual bool? Debug { get; internal set; }
    /// <summary>
    ///   Help for helm.
    /// </summary>
    public virtual bool? Help { get; internal set; }
    /// <summary>
    ///   Location of your Helm config. Overrides $HELM_HOME (default "~/.helm").
    /// </summary>
    public virtual string Home { get; internal set; }
    /// <summary>
    ///   Address of Tiller. Overrides $HELM_HOST.
    /// </summary>
    public virtual string Host { get; internal set; }
    /// <summary>
    ///   Name of the kubeconfig context to use.
    /// </summary>
    public virtual string KubeContext { get; internal set; }
    /// <summary>
    ///   Absolute path to the kubeconfig file to use.
    /// </summary>
    public virtual string Kubeconfig { get; internal set; }
    /// <summary>
    ///   The duration (in seconds) Helm will wait to establish a connection to tiller (default 300).
    /// </summary>
    public virtual long? TillerConnectionTimeout { get; internal set; }
    /// <summary>
    ///   Namespace of Tiller (default "kube-system").
    /// </summary>
    public virtual string TillerNamespace { get; internal set; }
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("--debug", Debug)
          .Add("--help", Help)
          .Add("--home {value}", Home)
          .Add("--host {value}", Host)
          .Add("--kube-context {value}", KubeContext)
          .Add("--kubeconfig {value}", Kubeconfig)
          .Add("--tiller-connection-timeout {value}", TillerConnectionTimeout)
          .Add("--tiller-namespace {value}", TillerNamespace);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region HelmCompletionSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmCompletionSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmCompletionSettings.Help"/></em></p>
    ///   <p>Help for completion.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmCompletionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmCompletionSettings.Help"/></em></p>
    ///   <p>Help for completion.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmCompletionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmCompletionSettings.Help"/></em></p>
    ///   <p>Help for completion.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmCompletionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmCompletionSettings.Help"/></em></p>
    ///   <p>Help for completion.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmCompletionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmCompletionSettings.Help"/></em></p>
    ///   <p>Help for completion.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmCompletionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Shell
    /// <summary>
    ///   <p><em>Sets <see cref="HelmCompletionSettings.Shell"/></em></p>
    /// </summary>
    [Pure]
    public static T SetShell<T>(this T toolSettings, string shell) where T : HelmCompletionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Shell = shell;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmCompletionSettings.Shell"/></em></p>
    /// </summary>
    [Pure]
    public static T ResetShell<T>(this T toolSettings) where T : HelmCompletionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Shell = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmCreateSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmCreateSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmCreateSettings.Help"/></em></p>
    ///   <p>Help for create.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmCreateSettings.Help"/></em></p>
    ///   <p>Help for create.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmCreateSettings.Help"/></em></p>
    ///   <p>Help for create.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmCreateSettings.Help"/></em></p>
    ///   <p>Help for create.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmCreateSettings.Help"/></em></p>
    ///   <p>Help for create.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Starter
    /// <summary>
    ///   <p><em>Sets <see cref="HelmCreateSettings.Starter"/></em></p>
    ///   <p>The named Helm starter scaffold.</p>
    /// </summary>
    [Pure]
    public static T SetStarter<T>(this T toolSettings, string starter) where T : HelmCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Starter = starter;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmCreateSettings.Starter"/></em></p>
    ///   <p>The named Helm starter scaffold.</p>
    /// </summary>
    [Pure]
    public static T ResetStarter<T>(this T toolSettings) where T : HelmCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Starter = null;
        return toolSettings;
    }
    #endregion
    #region Name
    /// <summary>
    ///   <p><em>Sets <see cref="HelmCreateSettings.Name"/></em></p>
    ///   <p>The name of chart directory to create.</p>
    /// </summary>
    [Pure]
    public static T SetName<T>(this T toolSettings, string name) where T : HelmCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Name = name;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmCreateSettings.Name"/></em></p>
    ///   <p>The name of chart directory to create.</p>
    /// </summary>
    [Pure]
    public static T ResetName<T>(this T toolSettings) where T : HelmCreateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Name = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmDeleteSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmDeleteSettingsExtensions
{
    #region Description
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDeleteSettings.Description"/></em></p>
    ///   <p>Specify a description for the release.</p>
    /// </summary>
    [Pure]
    public static T SetDescription<T>(this T toolSettings, string description) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Description = description;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDeleteSettings.Description"/></em></p>
    ///   <p>Specify a description for the release.</p>
    /// </summary>
    [Pure]
    public static T ResetDescription<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Description = null;
        return toolSettings;
    }
    #endregion
    #region DryRun
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDeleteSettings.DryRun"/></em></p>
    ///   <p>Simulate a delete.</p>
    /// </summary>
    [Pure]
    public static T SetDryRun<T>(this T toolSettings, bool? dryRun) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = dryRun;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDeleteSettings.DryRun"/></em></p>
    ///   <p>Simulate a delete.</p>
    /// </summary>
    [Pure]
    public static T ResetDryRun<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmDeleteSettings.DryRun"/></em></p>
    ///   <p>Simulate a delete.</p>
    /// </summary>
    [Pure]
    public static T EnableDryRun<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmDeleteSettings.DryRun"/></em></p>
    ///   <p>Simulate a delete.</p>
    /// </summary>
    [Pure]
    public static T DisableDryRun<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmDeleteSettings.DryRun"/></em></p>
    ///   <p>Simulate a delete.</p>
    /// </summary>
    [Pure]
    public static T ToggleDryRun<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = !toolSettings.DryRun;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDeleteSettings.Help"/></em></p>
    ///   <p>Help for delete.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDeleteSettings.Help"/></em></p>
    ///   <p>Help for delete.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmDeleteSettings.Help"/></em></p>
    ///   <p>Help for delete.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmDeleteSettings.Help"/></em></p>
    ///   <p>Help for delete.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmDeleteSettings.Help"/></em></p>
    ///   <p>Help for delete.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region NoHooks
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDeleteSettings.NoHooks"/></em></p>
    ///   <p>Prevent hooks from running during deletion.</p>
    /// </summary>
    [Pure]
    public static T SetNoHooks<T>(this T toolSettings, bool? noHooks) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = noHooks;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDeleteSettings.NoHooks"/></em></p>
    ///   <p>Prevent hooks from running during deletion.</p>
    /// </summary>
    [Pure]
    public static T ResetNoHooks<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmDeleteSettings.NoHooks"/></em></p>
    ///   <p>Prevent hooks from running during deletion.</p>
    /// </summary>
    [Pure]
    public static T EnableNoHooks<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmDeleteSettings.NoHooks"/></em></p>
    ///   <p>Prevent hooks from running during deletion.</p>
    /// </summary>
    [Pure]
    public static T DisableNoHooks<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmDeleteSettings.NoHooks"/></em></p>
    ///   <p>Prevent hooks from running during deletion.</p>
    /// </summary>
    [Pure]
    public static T ToggleNoHooks<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = !toolSettings.NoHooks;
        return toolSettings;
    }
    #endregion
    #region Purge
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDeleteSettings.Purge"/></em></p>
    ///   <p>Remove the release from the store and make its name free for later use.</p>
    /// </summary>
    [Pure]
    public static T SetPurge<T>(this T toolSettings, bool? purge) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Purge = purge;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDeleteSettings.Purge"/></em></p>
    ///   <p>Remove the release from the store and make its name free for later use.</p>
    /// </summary>
    [Pure]
    public static T ResetPurge<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Purge = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmDeleteSettings.Purge"/></em></p>
    ///   <p>Remove the release from the store and make its name free for later use.</p>
    /// </summary>
    [Pure]
    public static T EnablePurge<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Purge = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmDeleteSettings.Purge"/></em></p>
    ///   <p>Remove the release from the store and make its name free for later use.</p>
    /// </summary>
    [Pure]
    public static T DisablePurge<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Purge = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmDeleteSettings.Purge"/></em></p>
    ///   <p>Remove the release from the store and make its name free for later use.</p>
    /// </summary>
    [Pure]
    public static T TogglePurge<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Purge = !toolSettings.Purge;
        return toolSettings;
    }
    #endregion
    #region Timeout
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDeleteSettings.Timeout"/></em></p>
    ///   <p>Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).</p>
    /// </summary>
    [Pure]
    public static T SetTimeout<T>(this T toolSettings, long? timeout) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Timeout = timeout;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDeleteSettings.Timeout"/></em></p>
    ///   <p>Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).</p>
    /// </summary>
    [Pure]
    public static T ResetTimeout<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Timeout = null;
        return toolSettings;
    }
    #endregion
    #region Tls
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDeleteSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T SetTls<T>(this T toolSettings, bool? tls) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = tls;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDeleteSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ResetTls<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmDeleteSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T EnableTls<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmDeleteSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T DisableTls<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmDeleteSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ToggleTls<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = !toolSettings.Tls;
        return toolSettings;
    }
    #endregion
    #region TlsCaCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDeleteSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCaCert<T>(this T toolSettings, string tlsCaCert) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = tlsCaCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDeleteSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCaCert<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDeleteSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCert<T>(this T toolSettings, string tlsCert) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = tlsCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDeleteSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCert<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsHostname
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDeleteSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T SetTlsHostname<T>(this T toolSettings, string tlsHostname) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = tlsHostname;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDeleteSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsHostname<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = null;
        return toolSettings;
    }
    #endregion
    #region TlsKey
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDeleteSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsKey<T>(this T toolSettings, string tlsKey) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = tlsKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDeleteSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsKey<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = null;
        return toolSettings;
    }
    #endregion
    #region TlsVerify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDeleteSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T SetTlsVerify<T>(this T toolSettings, bool? tlsVerify) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = tlsVerify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDeleteSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsVerify<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmDeleteSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T EnableTlsVerify<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmDeleteSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T DisableTlsVerify<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmDeleteSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ToggleTlsVerify<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = !toolSettings.TlsVerify;
        return toolSettings;
    }
    #endregion
    #region ReleaseNames
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDeleteSettings.ReleaseNames"/> to a new list</em></p>
    ///   <p>The name of the releases to delete.</p>
    /// </summary>
    [Pure]
    public static T SetReleaseNames<T>(this T toolSettings, params string[] releaseNames) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseNamesInternal = releaseNames.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDeleteSettings.ReleaseNames"/> to a new list</em></p>
    ///   <p>The name of the releases to delete.</p>
    /// </summary>
    [Pure]
    public static T SetReleaseNames<T>(this T toolSettings, IEnumerable<string> releaseNames) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseNamesInternal = releaseNames.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmDeleteSettings.ReleaseNames"/></em></p>
    ///   <p>The name of the releases to delete.</p>
    /// </summary>
    [Pure]
    public static T AddReleaseNames<T>(this T toolSettings, params string[] releaseNames) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseNamesInternal.AddRange(releaseNames);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmDeleteSettings.ReleaseNames"/></em></p>
    ///   <p>The name of the releases to delete.</p>
    /// </summary>
    [Pure]
    public static T AddReleaseNames<T>(this T toolSettings, IEnumerable<string> releaseNames) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseNamesInternal.AddRange(releaseNames);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmDeleteSettings.ReleaseNames"/></em></p>
    ///   <p>The name of the releases to delete.</p>
    /// </summary>
    [Pure]
    public static T ClearReleaseNames<T>(this T toolSettings) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseNamesInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmDeleteSettings.ReleaseNames"/></em></p>
    ///   <p>The name of the releases to delete.</p>
    /// </summary>
    [Pure]
    public static T RemoveReleaseNames<T>(this T toolSettings, params string[] releaseNames) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(releaseNames);
        toolSettings.ReleaseNamesInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmDeleteSettings.ReleaseNames"/></em></p>
    ///   <p>The name of the releases to delete.</p>
    /// </summary>
    [Pure]
    public static T RemoveReleaseNames<T>(this T toolSettings, IEnumerable<string> releaseNames) where T : HelmDeleteSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(releaseNames);
        toolSettings.ReleaseNamesInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmDependencyBuildSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmDependencyBuildSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDependencyBuildSettings.Help"/></em></p>
    ///   <p>Help for build.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmDependencyBuildSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDependencyBuildSettings.Help"/></em></p>
    ///   <p>Help for build.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmDependencyBuildSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmDependencyBuildSettings.Help"/></em></p>
    ///   <p>Help for build.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmDependencyBuildSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmDependencyBuildSettings.Help"/></em></p>
    ///   <p>Help for build.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmDependencyBuildSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmDependencyBuildSettings.Help"/></em></p>
    ///   <p>Help for build.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmDependencyBuildSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Keyring
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDependencyBuildSettings.Keyring"/></em></p>
    ///   <p>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmDependencyBuildSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = keyring;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDependencyBuildSettings.Keyring"/></em></p>
    ///   <p>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T ResetKeyring<T>(this T toolSettings) where T : HelmDependencyBuildSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = null;
        return toolSettings;
    }
    #endregion
    #region Verify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDependencyBuildSettings.Verify"/></em></p>
    ///   <p>Verify the packages against signatures.</p>
    /// </summary>
    [Pure]
    public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmDependencyBuildSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = verify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDependencyBuildSettings.Verify"/></em></p>
    ///   <p>Verify the packages against signatures.</p>
    /// </summary>
    [Pure]
    public static T ResetVerify<T>(this T toolSettings) where T : HelmDependencyBuildSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmDependencyBuildSettings.Verify"/></em></p>
    ///   <p>Verify the packages against signatures.</p>
    /// </summary>
    [Pure]
    public static T EnableVerify<T>(this T toolSettings) where T : HelmDependencyBuildSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmDependencyBuildSettings.Verify"/></em></p>
    ///   <p>Verify the packages against signatures.</p>
    /// </summary>
    [Pure]
    public static T DisableVerify<T>(this T toolSettings) where T : HelmDependencyBuildSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmDependencyBuildSettings.Verify"/></em></p>
    ///   <p>Verify the packages against signatures.</p>
    /// </summary>
    [Pure]
    public static T ToggleVerify<T>(this T toolSettings) where T : HelmDependencyBuildSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = !toolSettings.Verify;
        return toolSettings;
    }
    #endregion
    #region Chart
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDependencyBuildSettings.Chart"/></em></p>
    ///   <p>The name of the chart to build.</p>
    /// </summary>
    [Pure]
    public static T SetChart<T>(this T toolSettings, string chart) where T : HelmDependencyBuildSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = chart;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDependencyBuildSettings.Chart"/></em></p>
    ///   <p>The name of the chart to build.</p>
    /// </summary>
    [Pure]
    public static T ResetChart<T>(this T toolSettings) where T : HelmDependencyBuildSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmDependencyListSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmDependencyListSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDependencyListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmDependencyListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDependencyListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmDependencyListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmDependencyListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmDependencyListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmDependencyListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmDependencyListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmDependencyListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmDependencyListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Chart
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDependencyListSettings.Chart"/></em></p>
    ///   <p>The name of the chart to list.</p>
    /// </summary>
    [Pure]
    public static T SetChart<T>(this T toolSettings, string chart) where T : HelmDependencyListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = chart;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDependencyListSettings.Chart"/></em></p>
    ///   <p>The name of the chart to list.</p>
    /// </summary>
    [Pure]
    public static T ResetChart<T>(this T toolSettings) where T : HelmDependencyListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmDependencyUpdateSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmDependencyUpdateSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDependencyUpdateSettings.Help"/></em></p>
    ///   <p>Help for update.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDependencyUpdateSettings.Help"/></em></p>
    ///   <p>Help for update.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmDependencyUpdateSettings.Help"/></em></p>
    ///   <p>Help for update.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmDependencyUpdateSettings.Help"/></em></p>
    ///   <p>Help for update.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmDependencyUpdateSettings.Help"/></em></p>
    ///   <p>Help for update.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Keyring
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDependencyUpdateSettings.Keyring"/></em></p>
    ///   <p>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = keyring;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDependencyUpdateSettings.Keyring"/></em></p>
    ///   <p>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T ResetKeyring<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = null;
        return toolSettings;
    }
    #endregion
    #region SkipRefresh
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></em></p>
    ///   <p>Do not refresh the local repository cache.</p>
    /// </summary>
    [Pure]
    public static T SetSkipRefresh<T>(this T toolSettings, bool? skipRefresh) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SkipRefresh = skipRefresh;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></em></p>
    ///   <p>Do not refresh the local repository cache.</p>
    /// </summary>
    [Pure]
    public static T ResetSkipRefresh<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SkipRefresh = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></em></p>
    ///   <p>Do not refresh the local repository cache.</p>
    /// </summary>
    [Pure]
    public static T EnableSkipRefresh<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SkipRefresh = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></em></p>
    ///   <p>Do not refresh the local repository cache.</p>
    /// </summary>
    [Pure]
    public static T DisableSkipRefresh<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SkipRefresh = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></em></p>
    ///   <p>Do not refresh the local repository cache.</p>
    /// </summary>
    [Pure]
    public static T ToggleSkipRefresh<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SkipRefresh = !toolSettings.SkipRefresh;
        return toolSettings;
    }
    #endregion
    #region Verify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDependencyUpdateSettings.Verify"/></em></p>
    ///   <p>Verify the packages against signatures.</p>
    /// </summary>
    [Pure]
    public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = verify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDependencyUpdateSettings.Verify"/></em></p>
    ///   <p>Verify the packages against signatures.</p>
    /// </summary>
    [Pure]
    public static T ResetVerify<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmDependencyUpdateSettings.Verify"/></em></p>
    ///   <p>Verify the packages against signatures.</p>
    /// </summary>
    [Pure]
    public static T EnableVerify<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmDependencyUpdateSettings.Verify"/></em></p>
    ///   <p>Verify the packages against signatures.</p>
    /// </summary>
    [Pure]
    public static T DisableVerify<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmDependencyUpdateSettings.Verify"/></em></p>
    ///   <p>Verify the packages against signatures.</p>
    /// </summary>
    [Pure]
    public static T ToggleVerify<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = !toolSettings.Verify;
        return toolSettings;
    }
    #endregion
    #region Chart
    /// <summary>
    ///   <p><em>Sets <see cref="HelmDependencyUpdateSettings.Chart"/></em></p>
    ///   <p>The name of the chart to update.</p>
    /// </summary>
    [Pure]
    public static T SetChart<T>(this T toolSettings, string chart) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = chart;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmDependencyUpdateSettings.Chart"/></em></p>
    ///   <p>The name of the chart to update.</p>
    /// </summary>
    [Pure]
    public static T ResetChart<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmFetchSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmFetchSettingsExtensions
{
    #region CaFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.CaFile"/></em></p>
    ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
    /// </summary>
    [Pure]
    public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CaFile = caFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmFetchSettings.CaFile"/></em></p>
    ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
    /// </summary>
    [Pure]
    public static T ResetCaFile<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CaFile = null;
        return toolSettings;
    }
    #endregion
    #region CertFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.CertFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL certificate file.</p>
    /// </summary>
    [Pure]
    public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CertFile = certFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmFetchSettings.CertFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL certificate file.</p>
    /// </summary>
    [Pure]
    public static T ResetCertFile<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CertFile = null;
        return toolSettings;
    }
    #endregion
    #region Destination
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.Destination"/></em></p>
    ///   <p>Location to write the chart. If this and tardir are specified, tardir is appended to this (default ".").</p>
    /// </summary>
    [Pure]
    public static T SetDestination<T>(this T toolSettings, string destination) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Destination = destination;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmFetchSettings.Destination"/></em></p>
    ///   <p>Location to write the chart. If this and tardir are specified, tardir is appended to this (default ".").</p>
    /// </summary>
    [Pure]
    public static T ResetDestination<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Destination = null;
        return toolSettings;
    }
    #endregion
    #region Devel
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T SetDevel<T>(this T toolSettings, bool? devel) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = devel;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmFetchSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T ResetDevel<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmFetchSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T EnableDevel<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmFetchSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T DisableDevel<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmFetchSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T ToggleDevel<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = !toolSettings.Devel;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.Help"/></em></p>
    ///   <p>Help for fetch.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmFetchSettings.Help"/></em></p>
    ///   <p>Help for fetch.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmFetchSettings.Help"/></em></p>
    ///   <p>Help for fetch.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmFetchSettings.Help"/></em></p>
    ///   <p>Help for fetch.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmFetchSettings.Help"/></em></p>
    ///   <p>Help for fetch.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region KeyFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.KeyFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL key file.</p>
    /// </summary>
    [Pure]
    public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KeyFile = keyFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmFetchSettings.KeyFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL key file.</p>
    /// </summary>
    [Pure]
    public static T ResetKeyFile<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KeyFile = null;
        return toolSettings;
    }
    #endregion
    #region Keyring
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.Keyring"/></em></p>
    ///   <p>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = keyring;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmFetchSettings.Keyring"/></em></p>
    ///   <p>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T ResetKeyring<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = null;
        return toolSettings;
    }
    #endregion
    #region Password
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.Password"/></em></p>
    ///   <p>Chart repository password.</p>
    /// </summary>
    [Pure]
    public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Password = password;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmFetchSettings.Password"/></em></p>
    ///   <p>Chart repository password.</p>
    /// </summary>
    [Pure]
    public static T ResetPassword<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Password = null;
        return toolSettings;
    }
    #endregion
    #region Prov
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.Prov"/></em></p>
    ///   <p>Fetch the provenance file, but don't perform verification.</p>
    /// </summary>
    [Pure]
    public static T SetProv<T>(this T toolSettings, bool? prov) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Prov = prov;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmFetchSettings.Prov"/></em></p>
    ///   <p>Fetch the provenance file, but don't perform verification.</p>
    /// </summary>
    [Pure]
    public static T ResetProv<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Prov = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmFetchSettings.Prov"/></em></p>
    ///   <p>Fetch the provenance file, but don't perform verification.</p>
    /// </summary>
    [Pure]
    public static T EnableProv<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Prov = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmFetchSettings.Prov"/></em></p>
    ///   <p>Fetch the provenance file, but don't perform verification.</p>
    /// </summary>
    [Pure]
    public static T DisableProv<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Prov = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmFetchSettings.Prov"/></em></p>
    ///   <p>Fetch the provenance file, but don't perform verification.</p>
    /// </summary>
    [Pure]
    public static T ToggleProv<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Prov = !toolSettings.Prov;
        return toolSettings;
    }
    #endregion
    #region Repo
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.Repo"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetRepo<T>(this T toolSettings, string repo) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Repo = repo;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmFetchSettings.Repo"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetRepo<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Repo = null;
        return toolSettings;
    }
    #endregion
    #region Untar
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.Untar"/></em></p>
    ///   <p>If set to true, will untar the chart after downloading it.</p>
    /// </summary>
    [Pure]
    public static T SetUntar<T>(this T toolSettings, bool? untar) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Untar = untar;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmFetchSettings.Untar"/></em></p>
    ///   <p>If set to true, will untar the chart after downloading it.</p>
    /// </summary>
    [Pure]
    public static T ResetUntar<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Untar = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmFetchSettings.Untar"/></em></p>
    ///   <p>If set to true, will untar the chart after downloading it.</p>
    /// </summary>
    [Pure]
    public static T EnableUntar<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Untar = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmFetchSettings.Untar"/></em></p>
    ///   <p>If set to true, will untar the chart after downloading it.</p>
    /// </summary>
    [Pure]
    public static T DisableUntar<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Untar = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmFetchSettings.Untar"/></em></p>
    ///   <p>If set to true, will untar the chart after downloading it.</p>
    /// </summary>
    [Pure]
    public static T ToggleUntar<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Untar = !toolSettings.Untar;
        return toolSettings;
    }
    #endregion
    #region Untardir
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.Untardir"/></em></p>
    ///   <p>If untar is specified, this flag specifies the name of the directory into which the chart is expanded (default ".").</p>
    /// </summary>
    [Pure]
    public static T SetUntardir<T>(this T toolSettings, string untardir) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Untardir = untardir;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmFetchSettings.Untardir"/></em></p>
    ///   <p>If untar is specified, this flag specifies the name of the directory into which the chart is expanded (default ".").</p>
    /// </summary>
    [Pure]
    public static T ResetUntardir<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Untardir = null;
        return toolSettings;
    }
    #endregion
    #region Username
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.Username"/></em></p>
    ///   <p>Chart repository username.</p>
    /// </summary>
    [Pure]
    public static T SetUsername<T>(this T toolSettings, string username) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Username = username;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmFetchSettings.Username"/></em></p>
    ///   <p>Chart repository username.</p>
    /// </summary>
    [Pure]
    public static T ResetUsername<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Username = null;
        return toolSettings;
    }
    #endregion
    #region Verify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.Verify"/></em></p>
    ///   <p>Verify the package against its signature.</p>
    /// </summary>
    [Pure]
    public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = verify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmFetchSettings.Verify"/></em></p>
    ///   <p>Verify the package against its signature.</p>
    /// </summary>
    [Pure]
    public static T ResetVerify<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmFetchSettings.Verify"/></em></p>
    ///   <p>Verify the package against its signature.</p>
    /// </summary>
    [Pure]
    public static T EnableVerify<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmFetchSettings.Verify"/></em></p>
    ///   <p>Verify the package against its signature.</p>
    /// </summary>
    [Pure]
    public static T DisableVerify<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmFetchSettings.Verify"/></em></p>
    ///   <p>Verify the package against its signature.</p>
    /// </summary>
    [Pure]
    public static T ToggleVerify<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = !toolSettings.Verify;
        return toolSettings;
    }
    #endregion
    #region Version
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.Version"/></em></p>
    ///   <p>Specific version of a chart. Without this, the latest version is fetched.</p>
    /// </summary>
    [Pure]
    public static T SetVersion<T>(this T toolSettings, string version) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = version;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmFetchSettings.Version"/></em></p>
    ///   <p>Specific version of a chart. Without this, the latest version is fetched.</p>
    /// </summary>
    [Pure]
    public static T ResetVersion<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = null;
        return toolSettings;
    }
    #endregion
    #region Charts
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.Charts"/> to a new list</em></p>
    ///   <p>The charts to fetch. Can either be specified by <c>repoName/chartName</c> or directly by an url.</p>
    /// </summary>
    [Pure]
    public static T SetCharts<T>(this T toolSettings, params string[] charts) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ChartsInternal = charts.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="HelmFetchSettings.Charts"/> to a new list</em></p>
    ///   <p>The charts to fetch. Can either be specified by <c>repoName/chartName</c> or directly by an url.</p>
    /// </summary>
    [Pure]
    public static T SetCharts<T>(this T toolSettings, IEnumerable<string> charts) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ChartsInternal = charts.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmFetchSettings.Charts"/></em></p>
    ///   <p>The charts to fetch. Can either be specified by <c>repoName/chartName</c> or directly by an url.</p>
    /// </summary>
    [Pure]
    public static T AddCharts<T>(this T toolSettings, params string[] charts) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ChartsInternal.AddRange(charts);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmFetchSettings.Charts"/></em></p>
    ///   <p>The charts to fetch. Can either be specified by <c>repoName/chartName</c> or directly by an url.</p>
    /// </summary>
    [Pure]
    public static T AddCharts<T>(this T toolSettings, IEnumerable<string> charts) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ChartsInternal.AddRange(charts);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmFetchSettings.Charts"/></em></p>
    ///   <p>The charts to fetch. Can either be specified by <c>repoName/chartName</c> or directly by an url.</p>
    /// </summary>
    [Pure]
    public static T ClearCharts<T>(this T toolSettings) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ChartsInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmFetchSettings.Charts"/></em></p>
    ///   <p>The charts to fetch. Can either be specified by <c>repoName/chartName</c> or directly by an url.</p>
    /// </summary>
    [Pure]
    public static T RemoveCharts<T>(this T toolSettings, params string[] charts) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(charts);
        toolSettings.ChartsInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmFetchSettings.Charts"/></em></p>
    ///   <p>The charts to fetch. Can either be specified by <c>repoName/chartName</c> or directly by an url.</p>
    /// </summary>
    [Pure]
    public static T RemoveCharts<T>(this T toolSettings, IEnumerable<string> charts) where T : HelmFetchSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(charts);
        toolSettings.ChartsInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmGetSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmGetSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetSettings.Help"/></em></p>
    ///   <p>Help for get.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetSettings.Help"/></em></p>
    ///   <p>Help for get.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmGetSettings.Help"/></em></p>
    ///   <p>Help for get.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmGetSettings.Help"/></em></p>
    ///   <p>Help for get.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmGetSettings.Help"/></em></p>
    ///   <p>Help for get.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Revision
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetSettings.Revision"/></em></p>
    ///   <p>Get the named release with revision.</p>
    /// </summary>
    [Pure]
    public static T SetRevision<T>(this T toolSettings, int? revision) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Revision = revision;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetSettings.Revision"/></em></p>
    ///   <p>Get the named release with revision.</p>
    /// </summary>
    [Pure]
    public static T ResetRevision<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Revision = null;
        return toolSettings;
    }
    #endregion
    #region Tls
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T SetTls<T>(this T toolSettings, bool? tls) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = tls;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ResetTls<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmGetSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T EnableTls<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmGetSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T DisableTls<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmGetSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ToggleTls<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = !toolSettings.Tls;
        return toolSettings;
    }
    #endregion
    #region TlsCaCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCaCert<T>(this T toolSettings, string tlsCaCert) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = tlsCaCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCaCert<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCert<T>(this T toolSettings, string tlsCert) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = tlsCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCert<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsHostname
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T SetTlsHostname<T>(this T toolSettings, string tlsHostname) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = tlsHostname;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsHostname<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = null;
        return toolSettings;
    }
    #endregion
    #region TlsKey
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsKey<T>(this T toolSettings, string tlsKey) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = tlsKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsKey<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = null;
        return toolSettings;
    }
    #endregion
    #region TlsVerify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T SetTlsVerify<T>(this T toolSettings, bool? tlsVerify) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = tlsVerify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsVerify<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmGetSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T EnableTlsVerify<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmGetSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T DisableTlsVerify<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmGetSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ToggleTlsVerify<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = !toolSettings.TlsVerify;
        return toolSettings;
    }
    #endregion
    #region ReleaseName
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetSettings.ReleaseName"/></em></p>
    ///   <p>The name of the release to get.</p>
    /// </summary>
    [Pure]
    public static T SetReleaseName<T>(this T toolSettings, string releaseName) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseName = releaseName;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetSettings.ReleaseName"/></em></p>
    ///   <p>The name of the release to get.</p>
    /// </summary>
    [Pure]
    public static T ResetReleaseName<T>(this T toolSettings) where T : HelmGetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseName = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmGetHooksSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmGetHooksSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetHooksSettings.Help"/></em></p>
    ///   <p>Help for hooks.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetHooksSettings.Help"/></em></p>
    ///   <p>Help for hooks.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmGetHooksSettings.Help"/></em></p>
    ///   <p>Help for hooks.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmGetHooksSettings.Help"/></em></p>
    ///   <p>Help for hooks.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmGetHooksSettings.Help"/></em></p>
    ///   <p>Help for hooks.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Revision
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetHooksSettings.Revision"/></em></p>
    ///   <p>Get the named release with revision.</p>
    /// </summary>
    [Pure]
    public static T SetRevision<T>(this T toolSettings, int? revision) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Revision = revision;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetHooksSettings.Revision"/></em></p>
    ///   <p>Get the named release with revision.</p>
    /// </summary>
    [Pure]
    public static T ResetRevision<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Revision = null;
        return toolSettings;
    }
    #endregion
    #region Tls
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetHooksSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T SetTls<T>(this T toolSettings, bool? tls) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = tls;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetHooksSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ResetTls<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmGetHooksSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T EnableTls<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmGetHooksSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T DisableTls<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmGetHooksSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ToggleTls<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = !toolSettings.Tls;
        return toolSettings;
    }
    #endregion
    #region TlsCaCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetHooksSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCaCert<T>(this T toolSettings, string tlsCaCert) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = tlsCaCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetHooksSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCaCert<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetHooksSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCert<T>(this T toolSettings, string tlsCert) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = tlsCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetHooksSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCert<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsHostname
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetHooksSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T SetTlsHostname<T>(this T toolSettings, string tlsHostname) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = tlsHostname;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetHooksSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsHostname<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = null;
        return toolSettings;
    }
    #endregion
    #region TlsKey
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetHooksSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsKey<T>(this T toolSettings, string tlsKey) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = tlsKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetHooksSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsKey<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = null;
        return toolSettings;
    }
    #endregion
    #region TlsVerify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetHooksSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T SetTlsVerify<T>(this T toolSettings, bool? tlsVerify) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = tlsVerify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetHooksSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsVerify<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmGetHooksSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T EnableTlsVerify<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmGetHooksSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T DisableTlsVerify<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmGetHooksSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ToggleTlsVerify<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = !toolSettings.TlsVerify;
        return toolSettings;
    }
    #endregion
    #region ReleaseName
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetHooksSettings.ReleaseName"/></em></p>
    ///   <p>The name of the release to get the hooks for.</p>
    /// </summary>
    [Pure]
    public static T SetReleaseName<T>(this T toolSettings, string releaseName) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseName = releaseName;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetHooksSettings.ReleaseName"/></em></p>
    ///   <p>The name of the release to get the hooks for.</p>
    /// </summary>
    [Pure]
    public static T ResetReleaseName<T>(this T toolSettings) where T : HelmGetHooksSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseName = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmGetManifestSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmGetManifestSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetManifestSettings.Help"/></em></p>
    ///   <p>Help for manifest.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetManifestSettings.Help"/></em></p>
    ///   <p>Help for manifest.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmGetManifestSettings.Help"/></em></p>
    ///   <p>Help for manifest.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmGetManifestSettings.Help"/></em></p>
    ///   <p>Help for manifest.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmGetManifestSettings.Help"/></em></p>
    ///   <p>Help for manifest.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Revision
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetManifestSettings.Revision"/></em></p>
    ///   <p>Get the named release with revision.</p>
    /// </summary>
    [Pure]
    public static T SetRevision<T>(this T toolSettings, int? revision) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Revision = revision;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetManifestSettings.Revision"/></em></p>
    ///   <p>Get the named release with revision.</p>
    /// </summary>
    [Pure]
    public static T ResetRevision<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Revision = null;
        return toolSettings;
    }
    #endregion
    #region Tls
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetManifestSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T SetTls<T>(this T toolSettings, bool? tls) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = tls;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetManifestSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ResetTls<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmGetManifestSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T EnableTls<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmGetManifestSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T DisableTls<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmGetManifestSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ToggleTls<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = !toolSettings.Tls;
        return toolSettings;
    }
    #endregion
    #region TlsCaCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetManifestSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCaCert<T>(this T toolSettings, string tlsCaCert) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = tlsCaCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetManifestSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCaCert<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetManifestSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCert<T>(this T toolSettings, string tlsCert) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = tlsCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetManifestSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCert<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsHostname
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetManifestSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T SetTlsHostname<T>(this T toolSettings, string tlsHostname) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = tlsHostname;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetManifestSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsHostname<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = null;
        return toolSettings;
    }
    #endregion
    #region TlsKey
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetManifestSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsKey<T>(this T toolSettings, string tlsKey) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = tlsKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetManifestSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsKey<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = null;
        return toolSettings;
    }
    #endregion
    #region TlsVerify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetManifestSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T SetTlsVerify<T>(this T toolSettings, bool? tlsVerify) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = tlsVerify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetManifestSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsVerify<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmGetManifestSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T EnableTlsVerify<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmGetManifestSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T DisableTlsVerify<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmGetManifestSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ToggleTlsVerify<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = !toolSettings.TlsVerify;
        return toolSettings;
    }
    #endregion
    #region ReleaseName
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetManifestSettings.ReleaseName"/></em></p>
    ///   <p>The name of the release to get the manifest for.</p>
    /// </summary>
    [Pure]
    public static T SetReleaseName<T>(this T toolSettings, string releaseName) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseName = releaseName;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetManifestSettings.ReleaseName"/></em></p>
    ///   <p>The name of the release to get the manifest for.</p>
    /// </summary>
    [Pure]
    public static T ResetReleaseName<T>(this T toolSettings) where T : HelmGetManifestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseName = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmGetNotesSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmGetNotesSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetNotesSettings.Help"/></em></p>
    ///   <p>Help for notes.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetNotesSettings.Help"/></em></p>
    ///   <p>Help for notes.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmGetNotesSettings.Help"/></em></p>
    ///   <p>Help for notes.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmGetNotesSettings.Help"/></em></p>
    ///   <p>Help for notes.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmGetNotesSettings.Help"/></em></p>
    ///   <p>Help for notes.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Revision
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetNotesSettings.Revision"/></em></p>
    ///   <p>Get the notes of the named release with revision.</p>
    /// </summary>
    [Pure]
    public static T SetRevision<T>(this T toolSettings, int? revision) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Revision = revision;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetNotesSettings.Revision"/></em></p>
    ///   <p>Get the notes of the named release with revision.</p>
    /// </summary>
    [Pure]
    public static T ResetRevision<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Revision = null;
        return toolSettings;
    }
    #endregion
    #region Tls
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetNotesSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T SetTls<T>(this T toolSettings, bool? tls) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = tls;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetNotesSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ResetTls<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmGetNotesSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T EnableTls<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmGetNotesSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T DisableTls<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmGetNotesSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ToggleTls<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = !toolSettings.Tls;
        return toolSettings;
    }
    #endregion
    #region TlsCaCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetNotesSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCaCert<T>(this T toolSettings, string tlsCaCert) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = tlsCaCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetNotesSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCaCert<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetNotesSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCert<T>(this T toolSettings, string tlsCert) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = tlsCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetNotesSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCert<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsHostname
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetNotesSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T SetTlsHostname<T>(this T toolSettings, string tlsHostname) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = tlsHostname;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetNotesSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsHostname<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = null;
        return toolSettings;
    }
    #endregion
    #region TlsKey
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetNotesSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsKey<T>(this T toolSettings, string tlsKey) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = tlsKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetNotesSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsKey<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = null;
        return toolSettings;
    }
    #endregion
    #region TlsVerify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetNotesSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T SetTlsVerify<T>(this T toolSettings, bool? tlsVerify) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = tlsVerify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetNotesSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsVerify<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmGetNotesSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T EnableTlsVerify<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmGetNotesSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T DisableTlsVerify<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmGetNotesSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ToggleTlsVerify<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = !toolSettings.TlsVerify;
        return toolSettings;
    }
    #endregion
    #region ReleaseName
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetNotesSettings.ReleaseName"/></em></p>
    /// </summary>
    [Pure]
    public static T SetReleaseName<T>(this T toolSettings, string releaseName) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseName = releaseName;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetNotesSettings.ReleaseName"/></em></p>
    /// </summary>
    [Pure]
    public static T ResetReleaseName<T>(this T toolSettings) where T : HelmGetNotesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseName = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmGetValuesSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmGetValuesSettingsExtensions
{
    #region All
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetValuesSettings.All"/></em></p>
    ///   <p>Dump all (computed) values.</p>
    /// </summary>
    [Pure]
    public static T SetAll<T>(this T toolSettings, bool? all) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.All = all;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetValuesSettings.All"/></em></p>
    ///   <p>Dump all (computed) values.</p>
    /// </summary>
    [Pure]
    public static T ResetAll<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.All = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmGetValuesSettings.All"/></em></p>
    ///   <p>Dump all (computed) values.</p>
    /// </summary>
    [Pure]
    public static T EnableAll<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.All = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmGetValuesSettings.All"/></em></p>
    ///   <p>Dump all (computed) values.</p>
    /// </summary>
    [Pure]
    public static T DisableAll<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.All = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmGetValuesSettings.All"/></em></p>
    ///   <p>Dump all (computed) values.</p>
    /// </summary>
    [Pure]
    public static T ToggleAll<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.All = !toolSettings.All;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetValuesSettings.Help"/></em></p>
    ///   <p>Help for values.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetValuesSettings.Help"/></em></p>
    ///   <p>Help for values.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmGetValuesSettings.Help"/></em></p>
    ///   <p>Help for values.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmGetValuesSettings.Help"/></em></p>
    ///   <p>Help for values.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmGetValuesSettings.Help"/></em></p>
    ///   <p>Help for values.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Output
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetValuesSettings.Output"/></em></p>
    ///   <p>Output the specified format (json or yaml) (default "yaml").</p>
    /// </summary>
    [Pure]
    public static T SetOutput<T>(this T toolSettings, string output) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = output;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetValuesSettings.Output"/></em></p>
    ///   <p>Output the specified format (json or yaml) (default "yaml").</p>
    /// </summary>
    [Pure]
    public static T ResetOutput<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = null;
        return toolSettings;
    }
    #endregion
    #region Revision
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetValuesSettings.Revision"/></em></p>
    ///   <p>Get the named release with revision.</p>
    /// </summary>
    [Pure]
    public static T SetRevision<T>(this T toolSettings, int? revision) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Revision = revision;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetValuesSettings.Revision"/></em></p>
    ///   <p>Get the named release with revision.</p>
    /// </summary>
    [Pure]
    public static T ResetRevision<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Revision = null;
        return toolSettings;
    }
    #endregion
    #region Tls
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetValuesSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T SetTls<T>(this T toolSettings, bool? tls) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = tls;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetValuesSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ResetTls<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmGetValuesSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T EnableTls<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmGetValuesSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T DisableTls<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmGetValuesSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ToggleTls<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = !toolSettings.Tls;
        return toolSettings;
    }
    #endregion
    #region TlsCaCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetValuesSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCaCert<T>(this T toolSettings, string tlsCaCert) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = tlsCaCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetValuesSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCaCert<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetValuesSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCert<T>(this T toolSettings, string tlsCert) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = tlsCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetValuesSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCert<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsHostname
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetValuesSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T SetTlsHostname<T>(this T toolSettings, string tlsHostname) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = tlsHostname;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetValuesSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsHostname<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = null;
        return toolSettings;
    }
    #endregion
    #region TlsKey
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetValuesSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsKey<T>(this T toolSettings, string tlsKey) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = tlsKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetValuesSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsKey<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = null;
        return toolSettings;
    }
    #endregion
    #region TlsVerify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetValuesSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T SetTlsVerify<T>(this T toolSettings, bool? tlsVerify) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = tlsVerify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetValuesSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsVerify<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmGetValuesSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T EnableTlsVerify<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmGetValuesSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T DisableTlsVerify<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmGetValuesSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ToggleTlsVerify<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = !toolSettings.TlsVerify;
        return toolSettings;
    }
    #endregion
    #region ReleaseName
    /// <summary>
    ///   <p><em>Sets <see cref="HelmGetValuesSettings.ReleaseName"/></em></p>
    ///   <p>The name of the release to get the values for.</p>
    /// </summary>
    [Pure]
    public static T SetReleaseName<T>(this T toolSettings, string releaseName) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseName = releaseName;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmGetValuesSettings.ReleaseName"/></em></p>
    ///   <p>The name of the release to get the values for.</p>
    /// </summary>
    [Pure]
    public static T ResetReleaseName<T>(this T toolSettings) where T : HelmGetValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseName = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmHistorySettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmHistorySettingsExtensions
{
    #region ColWidth
    /// <summary>
    ///   <p><em>Sets <see cref="HelmHistorySettings.ColWidth"/></em></p>
    ///   <p>Specifies the max column width of output (default 60).</p>
    /// </summary>
    [Pure]
    public static T SetColWidth<T>(this T toolSettings, uint? colWidth) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ColWidth = colWidth;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmHistorySettings.ColWidth"/></em></p>
    ///   <p>Specifies the max column width of output (default 60).</p>
    /// </summary>
    [Pure]
    public static T ResetColWidth<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ColWidth = null;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmHistorySettings.Help"/></em></p>
    ///   <p>Help for history.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmHistorySettings.Help"/></em></p>
    ///   <p>Help for history.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmHistorySettings.Help"/></em></p>
    ///   <p>Help for history.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmHistorySettings.Help"/></em></p>
    ///   <p>Help for history.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmHistorySettings.Help"/></em></p>
    ///   <p>Help for history.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Max
    /// <summary>
    ///   <p><em>Sets <see cref="HelmHistorySettings.Max"/></em></p>
    ///   <p>Maximum number of revision to include in history (default 256).</p>
    /// </summary>
    [Pure]
    public static T SetMax<T>(this T toolSettings, int? max) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Max = max;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmHistorySettings.Max"/></em></p>
    ///   <p>Maximum number of revision to include in history (default 256).</p>
    /// </summary>
    [Pure]
    public static T ResetMax<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Max = null;
        return toolSettings;
    }
    #endregion
    #region Output
    /// <summary>
    ///   <p><em>Sets <see cref="HelmHistorySettings.Output"/></em></p>
    ///   <p>Prints the output in the specified format (json|table|yaml) (default "table").</p>
    /// </summary>
    [Pure]
    public static T SetOutput<T>(this T toolSettings, string output) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = output;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmHistorySettings.Output"/></em></p>
    ///   <p>Prints the output in the specified format (json|table|yaml) (default "table").</p>
    /// </summary>
    [Pure]
    public static T ResetOutput<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = null;
        return toolSettings;
    }
    #endregion
    #region Tls
    /// <summary>
    ///   <p><em>Sets <see cref="HelmHistorySettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T SetTls<T>(this T toolSettings, bool? tls) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = tls;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmHistorySettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ResetTls<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmHistorySettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T EnableTls<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmHistorySettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T DisableTls<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmHistorySettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ToggleTls<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = !toolSettings.Tls;
        return toolSettings;
    }
    #endregion
    #region TlsCaCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmHistorySettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCaCert<T>(this T toolSettings, string tlsCaCert) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = tlsCaCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmHistorySettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCaCert<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmHistorySettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCert<T>(this T toolSettings, string tlsCert) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = tlsCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmHistorySettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCert<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsHostname
    /// <summary>
    ///   <p><em>Sets <see cref="HelmHistorySettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T SetTlsHostname<T>(this T toolSettings, string tlsHostname) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = tlsHostname;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmHistorySettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsHostname<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = null;
        return toolSettings;
    }
    #endregion
    #region TlsKey
    /// <summary>
    ///   <p><em>Sets <see cref="HelmHistorySettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsKey<T>(this T toolSettings, string tlsKey) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = tlsKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmHistorySettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsKey<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = null;
        return toolSettings;
    }
    #endregion
    #region TlsVerify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmHistorySettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T SetTlsVerify<T>(this T toolSettings, bool? tlsVerify) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = tlsVerify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmHistorySettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsVerify<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmHistorySettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T EnableTlsVerify<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmHistorySettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T DisableTlsVerify<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmHistorySettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ToggleTlsVerify<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = !toolSettings.TlsVerify;
        return toolSettings;
    }
    #endregion
    #region ReleaseName
    /// <summary>
    ///   <p><em>Sets <see cref="HelmHistorySettings.ReleaseName"/></em></p>
    ///   <p>The name of the release to get the history for.</p>
    /// </summary>
    [Pure]
    public static T SetReleaseName<T>(this T toolSettings, string releaseName) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseName = releaseName;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmHistorySettings.ReleaseName"/></em></p>
    ///   <p>The name of the release to get the history for.</p>
    /// </summary>
    [Pure]
    public static T ResetReleaseName<T>(this T toolSettings) where T : HelmHistorySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseName = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmHomeSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmHomeSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmHomeSettings.Help"/></em></p>
    ///   <p>Help for home.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmHomeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmHomeSettings.Help"/></em></p>
    ///   <p>Help for home.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmHomeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmHomeSettings.Help"/></em></p>
    ///   <p>Help for home.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmHomeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmHomeSettings.Help"/></em></p>
    ///   <p>Help for home.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmHomeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmHomeSettings.Help"/></em></p>
    ///   <p>Help for home.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmHomeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmInitSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmInitSettingsExtensions
{
    #region AutomountServiceAccountToken
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.AutomountServiceAccountToken"/></em></p>
    ///   <p>Auto-mount the given service account to tiller (default true).</p>
    /// </summary>
    [Pure]
    public static T SetAutomountServiceAccountToken<T>(this T toolSettings, bool? automountServiceAccountToken) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AutomountServiceAccountToken = automountServiceAccountToken;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.AutomountServiceAccountToken"/></em></p>
    ///   <p>Auto-mount the given service account to tiller (default true).</p>
    /// </summary>
    [Pure]
    public static T ResetAutomountServiceAccountToken<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AutomountServiceAccountToken = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInitSettings.AutomountServiceAccountToken"/></em></p>
    ///   <p>Auto-mount the given service account to tiller (default true).</p>
    /// </summary>
    [Pure]
    public static T EnableAutomountServiceAccountToken<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AutomountServiceAccountToken = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInitSettings.AutomountServiceAccountToken"/></em></p>
    ///   <p>Auto-mount the given service account to tiller (default true).</p>
    /// </summary>
    [Pure]
    public static T DisableAutomountServiceAccountToken<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AutomountServiceAccountToken = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInitSettings.AutomountServiceAccountToken"/></em></p>
    ///   <p>Auto-mount the given service account to tiller (default true).</p>
    /// </summary>
    [Pure]
    public static T ToggleAutomountServiceAccountToken<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AutomountServiceAccountToken = !toolSettings.AutomountServiceAccountToken;
        return toolSettings;
    }
    #endregion
    #region CanaryImage
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.CanaryImage"/></em></p>
    ///   <p>Use the canary Tiller image.</p>
    /// </summary>
    [Pure]
    public static T SetCanaryImage<T>(this T toolSettings, bool? canaryImage) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CanaryImage = canaryImage;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.CanaryImage"/></em></p>
    ///   <p>Use the canary Tiller image.</p>
    /// </summary>
    [Pure]
    public static T ResetCanaryImage<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CanaryImage = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInitSettings.CanaryImage"/></em></p>
    ///   <p>Use the canary Tiller image.</p>
    /// </summary>
    [Pure]
    public static T EnableCanaryImage<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CanaryImage = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInitSettings.CanaryImage"/></em></p>
    ///   <p>Use the canary Tiller image.</p>
    /// </summary>
    [Pure]
    public static T DisableCanaryImage<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CanaryImage = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInitSettings.CanaryImage"/></em></p>
    ///   <p>Use the canary Tiller image.</p>
    /// </summary>
    [Pure]
    public static T ToggleCanaryImage<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CanaryImage = !toolSettings.CanaryImage;
        return toolSettings;
    }
    #endregion
    #region ClientOnly
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.ClientOnly"/></em></p>
    ///   <p>If set does not install Tiller.</p>
    /// </summary>
    [Pure]
    public static T SetClientOnly<T>(this T toolSettings, bool? clientOnly) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ClientOnly = clientOnly;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.ClientOnly"/></em></p>
    ///   <p>If set does not install Tiller.</p>
    /// </summary>
    [Pure]
    public static T ResetClientOnly<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ClientOnly = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInitSettings.ClientOnly"/></em></p>
    ///   <p>If set does not install Tiller.</p>
    /// </summary>
    [Pure]
    public static T EnableClientOnly<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ClientOnly = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInitSettings.ClientOnly"/></em></p>
    ///   <p>If set does not install Tiller.</p>
    /// </summary>
    [Pure]
    public static T DisableClientOnly<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ClientOnly = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInitSettings.ClientOnly"/></em></p>
    ///   <p>If set does not install Tiller.</p>
    /// </summary>
    [Pure]
    public static T ToggleClientOnly<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ClientOnly = !toolSettings.ClientOnly;
        return toolSettings;
    }
    #endregion
    #region DryRun
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.DryRun"/></em></p>
    ///   <p>Do not install local or remote.</p>
    /// </summary>
    [Pure]
    public static T SetDryRun<T>(this T toolSettings, bool? dryRun) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = dryRun;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.DryRun"/></em></p>
    ///   <p>Do not install local or remote.</p>
    /// </summary>
    [Pure]
    public static T ResetDryRun<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInitSettings.DryRun"/></em></p>
    ///   <p>Do not install local or remote.</p>
    /// </summary>
    [Pure]
    public static T EnableDryRun<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInitSettings.DryRun"/></em></p>
    ///   <p>Do not install local or remote.</p>
    /// </summary>
    [Pure]
    public static T DisableDryRun<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInitSettings.DryRun"/></em></p>
    ///   <p>Do not install local or remote.</p>
    /// </summary>
    [Pure]
    public static T ToggleDryRun<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = !toolSettings.DryRun;
        return toolSettings;
    }
    #endregion
    #region ForceUpgrade
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.ForceUpgrade"/></em></p>
    ///   <p>Force upgrade of Tiller to the current helm version.</p>
    /// </summary>
    [Pure]
    public static T SetForceUpgrade<T>(this T toolSettings, bool? forceUpgrade) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ForceUpgrade = forceUpgrade;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.ForceUpgrade"/></em></p>
    ///   <p>Force upgrade of Tiller to the current helm version.</p>
    /// </summary>
    [Pure]
    public static T ResetForceUpgrade<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ForceUpgrade = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInitSettings.ForceUpgrade"/></em></p>
    ///   <p>Force upgrade of Tiller to the current helm version.</p>
    /// </summary>
    [Pure]
    public static T EnableForceUpgrade<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ForceUpgrade = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInitSettings.ForceUpgrade"/></em></p>
    ///   <p>Force upgrade of Tiller to the current helm version.</p>
    /// </summary>
    [Pure]
    public static T DisableForceUpgrade<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ForceUpgrade = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInitSettings.ForceUpgrade"/></em></p>
    ///   <p>Force upgrade of Tiller to the current helm version.</p>
    /// </summary>
    [Pure]
    public static T ToggleForceUpgrade<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ForceUpgrade = !toolSettings.ForceUpgrade;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.Help"/></em></p>
    ///   <p>Help for init.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.Help"/></em></p>
    ///   <p>Help for init.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInitSettings.Help"/></em></p>
    ///   <p>Help for init.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInitSettings.Help"/></em></p>
    ///   <p>Help for init.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInitSettings.Help"/></em></p>
    ///   <p>Help for init.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region HistoryMax
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.HistoryMax"/></em></p>
    ///   <p>Limit the maximum number of revisions saved per release. Use 0 for no limit.</p>
    /// </summary>
    [Pure]
    public static T SetHistoryMax<T>(this T toolSettings, long? historyMax) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.HistoryMax = historyMax;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.HistoryMax"/></em></p>
    ///   <p>Limit the maximum number of revisions saved per release. Use 0 for no limit.</p>
    /// </summary>
    [Pure]
    public static T ResetHistoryMax<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.HistoryMax = null;
        return toolSettings;
    }
    #endregion
    #region LocalRepoUrl
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.LocalRepoUrl"/></em></p>
    ///   <p>URL for local repository (default "http://127.0.0.1:8879/charts").</p>
    /// </summary>
    [Pure]
    public static T SetLocalRepoUrl<T>(this T toolSettings, string localRepoUrl) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.LocalRepoUrl = localRepoUrl;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.LocalRepoUrl"/></em></p>
    ///   <p>URL for local repository (default "http://127.0.0.1:8879/charts").</p>
    /// </summary>
    [Pure]
    public static T ResetLocalRepoUrl<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.LocalRepoUrl = null;
        return toolSettings;
    }
    #endregion
    #region NetHost
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.NetHost"/></em></p>
    ///   <p>Install Tiller with net=host.</p>
    /// </summary>
    [Pure]
    public static T SetNetHost<T>(this T toolSettings, bool? netHost) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NetHost = netHost;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.NetHost"/></em></p>
    ///   <p>Install Tiller with net=host.</p>
    /// </summary>
    [Pure]
    public static T ResetNetHost<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NetHost = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInitSettings.NetHost"/></em></p>
    ///   <p>Install Tiller with net=host.</p>
    /// </summary>
    [Pure]
    public static T EnableNetHost<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NetHost = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInitSettings.NetHost"/></em></p>
    ///   <p>Install Tiller with net=host.</p>
    /// </summary>
    [Pure]
    public static T DisableNetHost<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NetHost = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInitSettings.NetHost"/></em></p>
    ///   <p>Install Tiller with net=host.</p>
    /// </summary>
    [Pure]
    public static T ToggleNetHost<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NetHost = !toolSettings.NetHost;
        return toolSettings;
    }
    #endregion
    #region NodeSelectors
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.NodeSelectors"/></em></p>
    ///   <p>Labels to specify the node on which Tiller is installed (app=tiller,helm=rocks).</p>
    /// </summary>
    [Pure]
    public static T SetNodeSelectors<T>(this T toolSettings, string nodeSelectors) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NodeSelectors = nodeSelectors;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.NodeSelectors"/></em></p>
    ///   <p>Labels to specify the node on which Tiller is installed (app=tiller,helm=rocks).</p>
    /// </summary>
    [Pure]
    public static T ResetNodeSelectors<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NodeSelectors = null;
        return toolSettings;
    }
    #endregion
    #region Output
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.Output"/></em></p>
    ///   <p>Skip installation and output Tiller's manifest in specified format (json or yaml).</p>
    /// </summary>
    [Pure]
    public static T SetOutput<T>(this T toolSettings, HelmOutputFormat output) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = output;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.Output"/></em></p>
    ///   <p>Skip installation and output Tiller's manifest in specified format (json or yaml).</p>
    /// </summary>
    [Pure]
    public static T ResetOutput<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = null;
        return toolSettings;
    }
    #endregion
    #region Override
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.Override"/> to a new dictionary</em></p>
    ///   <p>Override values for the Tiller Deployment manifest (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetOverride<T>(this T toolSettings, IDictionary<string, object> @override) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.OverrideInternal = @override.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmInitSettings.Override"/></em></p>
    ///   <p>Override values for the Tiller Deployment manifest (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T ClearOverride<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.OverrideInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds a new key-value-pair <see cref="HelmInitSettings.Override"/></em></p>
    ///   <p>Override values for the Tiller Deployment manifest (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T AddOverride<T>(this T toolSettings, string overrideKey, object overrideValue) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.OverrideInternal.Add(overrideKey, overrideValue);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes a key-value-pair from <see cref="HelmInitSettings.Override"/></em></p>
    ///   <p>Override values for the Tiller Deployment manifest (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T RemoveOverride<T>(this T toolSettings, string overrideKey) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.OverrideInternal.Remove(overrideKey);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets a key-value-pair in <see cref="HelmInitSettings.Override"/></em></p>
    ///   <p>Override values for the Tiller Deployment manifest (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetOverride<T>(this T toolSettings, string overrideKey, object overrideValue) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.OverrideInternal[overrideKey] = overrideValue;
        return toolSettings;
    }
    #endregion
    #region Replicas
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.Replicas"/></em></p>
    ///   <p>Amount of tiller instances to run on the cluster (default 1).</p>
    /// </summary>
    [Pure]
    public static T SetReplicas<T>(this T toolSettings, long? replicas) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Replicas = replicas;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.Replicas"/></em></p>
    ///   <p>Amount of tiller instances to run on the cluster (default 1).</p>
    /// </summary>
    [Pure]
    public static T ResetReplicas<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Replicas = null;
        return toolSettings;
    }
    #endregion
    #region ServiceAccount
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.ServiceAccount"/></em></p>
    ///   <p>Name of service account.</p>
    /// </summary>
    [Pure]
    public static T SetServiceAccount<T>(this T toolSettings, string serviceAccount) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ServiceAccount = serviceAccount;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.ServiceAccount"/></em></p>
    ///   <p>Name of service account.</p>
    /// </summary>
    [Pure]
    public static T ResetServiceAccount<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ServiceAccount = null;
        return toolSettings;
    }
    #endregion
    #region SkipRefresh
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.SkipRefresh"/></em></p>
    ///   <p>Do not refresh (download) the local repository cache.</p>
    /// </summary>
    [Pure]
    public static T SetSkipRefresh<T>(this T toolSettings, bool? skipRefresh) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SkipRefresh = skipRefresh;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.SkipRefresh"/></em></p>
    ///   <p>Do not refresh (download) the local repository cache.</p>
    /// </summary>
    [Pure]
    public static T ResetSkipRefresh<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SkipRefresh = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInitSettings.SkipRefresh"/></em></p>
    ///   <p>Do not refresh (download) the local repository cache.</p>
    /// </summary>
    [Pure]
    public static T EnableSkipRefresh<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SkipRefresh = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInitSettings.SkipRefresh"/></em></p>
    ///   <p>Do not refresh (download) the local repository cache.</p>
    /// </summary>
    [Pure]
    public static T DisableSkipRefresh<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SkipRefresh = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInitSettings.SkipRefresh"/></em></p>
    ///   <p>Do not refresh (download) the local repository cache.</p>
    /// </summary>
    [Pure]
    public static T ToggleSkipRefresh<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SkipRefresh = !toolSettings.SkipRefresh;
        return toolSettings;
    }
    #endregion
    #region StableRepoUrl
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.StableRepoUrl"/></em></p>
    ///   <p>URL for stable repository (default "https://kubernetes-charts.storage.googleapis.com").</p>
    /// </summary>
    [Pure]
    public static T SetStableRepoUrl<T>(this T toolSettings, string stableRepoUrl) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.StableRepoUrl = stableRepoUrl;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.StableRepoUrl"/></em></p>
    ///   <p>URL for stable repository (default "https://kubernetes-charts.storage.googleapis.com").</p>
    /// </summary>
    [Pure]
    public static T ResetStableRepoUrl<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.StableRepoUrl = null;
        return toolSettings;
    }
    #endregion
    #region TillerImage
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.TillerImage"/></em></p>
    ///   <p>Override Tiller image.</p>
    /// </summary>
    [Pure]
    public static T SetTillerImage<T>(this T toolSettings, string tillerImage) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerImage = tillerImage;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.TillerImage"/></em></p>
    ///   <p>Override Tiller image.</p>
    /// </summary>
    [Pure]
    public static T ResetTillerImage<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerImage = null;
        return toolSettings;
    }
    #endregion
    #region TillerTls
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.TillerTls"/></em></p>
    ///   <p>Install Tiller with TLS enabled.</p>
    /// </summary>
    [Pure]
    public static T SetTillerTls<T>(this T toolSettings, bool? tillerTls) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerTls = tillerTls;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.TillerTls"/></em></p>
    ///   <p>Install Tiller with TLS enabled.</p>
    /// </summary>
    [Pure]
    public static T ResetTillerTls<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerTls = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInitSettings.TillerTls"/></em></p>
    ///   <p>Install Tiller with TLS enabled.</p>
    /// </summary>
    [Pure]
    public static T EnableTillerTls<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerTls = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInitSettings.TillerTls"/></em></p>
    ///   <p>Install Tiller with TLS enabled.</p>
    /// </summary>
    [Pure]
    public static T DisableTillerTls<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerTls = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInitSettings.TillerTls"/></em></p>
    ///   <p>Install Tiller with TLS enabled.</p>
    /// </summary>
    [Pure]
    public static T ToggleTillerTls<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerTls = !toolSettings.TillerTls;
        return toolSettings;
    }
    #endregion
    #region TillerTlsCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.TillerTlsCert"/></em></p>
    ///   <p>Path to TLS certificate file to install with Tiller.</p>
    /// </summary>
    [Pure]
    public static T SetTillerTlsCert<T>(this T toolSettings, string tillerTlsCert) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerTlsCert = tillerTlsCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.TillerTlsCert"/></em></p>
    ///   <p>Path to TLS certificate file to install with Tiller.</p>
    /// </summary>
    [Pure]
    public static T ResetTillerTlsCert<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerTlsCert = null;
        return toolSettings;
    }
    #endregion
    #region TillerTlsHostname
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.TillerTlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from Tiller.</p>
    /// </summary>
    [Pure]
    public static T SetTillerTlsHostname<T>(this T toolSettings, string tillerTlsHostname) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerTlsHostname = tillerTlsHostname;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.TillerTlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from Tiller.</p>
    /// </summary>
    [Pure]
    public static T ResetTillerTlsHostname<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerTlsHostname = null;
        return toolSettings;
    }
    #endregion
    #region TillerTlsKey
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.TillerTlsKey"/></em></p>
    ///   <p>Path to TLS key file to install with Tiller.</p>
    /// </summary>
    [Pure]
    public static T SetTillerTlsKey<T>(this T toolSettings, string tillerTlsKey) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerTlsKey = tillerTlsKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.TillerTlsKey"/></em></p>
    ///   <p>Path to TLS key file to install with Tiller.</p>
    /// </summary>
    [Pure]
    public static T ResetTillerTlsKey<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerTlsKey = null;
        return toolSettings;
    }
    #endregion
    #region TillerTlsVerify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.TillerTlsVerify"/></em></p>
    ///   <p>Install Tiller with TLS enabled and to verify remote certificates.</p>
    /// </summary>
    [Pure]
    public static T SetTillerTlsVerify<T>(this T toolSettings, bool? tillerTlsVerify) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerTlsVerify = tillerTlsVerify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.TillerTlsVerify"/></em></p>
    ///   <p>Install Tiller with TLS enabled and to verify remote certificates.</p>
    /// </summary>
    [Pure]
    public static T ResetTillerTlsVerify<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerTlsVerify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInitSettings.TillerTlsVerify"/></em></p>
    ///   <p>Install Tiller with TLS enabled and to verify remote certificates.</p>
    /// </summary>
    [Pure]
    public static T EnableTillerTlsVerify<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerTlsVerify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInitSettings.TillerTlsVerify"/></em></p>
    ///   <p>Install Tiller with TLS enabled and to verify remote certificates.</p>
    /// </summary>
    [Pure]
    public static T DisableTillerTlsVerify<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerTlsVerify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInitSettings.TillerTlsVerify"/></em></p>
    ///   <p>Install Tiller with TLS enabled and to verify remote certificates.</p>
    /// </summary>
    [Pure]
    public static T ToggleTillerTlsVerify<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerTlsVerify = !toolSettings.TillerTlsVerify;
        return toolSettings;
    }
    #endregion
    #region TlsCaCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.TlsCaCert"/></em></p>
    ///   <p>Path to CA root certificate.</p>
    /// </summary>
    [Pure]
    public static T SetTlsCaCert<T>(this T toolSettings, string tlsCaCert) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = tlsCaCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.TlsCaCert"/></em></p>
    ///   <p>Path to CA root certificate.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCaCert<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = null;
        return toolSettings;
    }
    #endregion
    #region Upgrade
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.Upgrade"/></em></p>
    ///   <p>Upgrade if Tiller is already installed.</p>
    /// </summary>
    [Pure]
    public static T SetUpgrade<T>(this T toolSettings, bool? upgrade) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Upgrade = upgrade;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.Upgrade"/></em></p>
    ///   <p>Upgrade if Tiller is already installed.</p>
    /// </summary>
    [Pure]
    public static T ResetUpgrade<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Upgrade = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInitSettings.Upgrade"/></em></p>
    ///   <p>Upgrade if Tiller is already installed.</p>
    /// </summary>
    [Pure]
    public static T EnableUpgrade<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Upgrade = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInitSettings.Upgrade"/></em></p>
    ///   <p>Upgrade if Tiller is already installed.</p>
    /// </summary>
    [Pure]
    public static T DisableUpgrade<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Upgrade = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInitSettings.Upgrade"/></em></p>
    ///   <p>Upgrade if Tiller is already installed.</p>
    /// </summary>
    [Pure]
    public static T ToggleUpgrade<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Upgrade = !toolSettings.Upgrade;
        return toolSettings;
    }
    #endregion
    #region Wait
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInitSettings.Wait"/></em></p>
    ///   <p>Block until Tiller is running and ready to receive requests.</p>
    /// </summary>
    [Pure]
    public static T SetWait<T>(this T toolSettings, bool? wait) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = wait;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInitSettings.Wait"/></em></p>
    ///   <p>Block until Tiller is running and ready to receive requests.</p>
    /// </summary>
    [Pure]
    public static T ResetWait<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInitSettings.Wait"/></em></p>
    ///   <p>Block until Tiller is running and ready to receive requests.</p>
    /// </summary>
    [Pure]
    public static T EnableWait<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInitSettings.Wait"/></em></p>
    ///   <p>Block until Tiller is running and ready to receive requests.</p>
    /// </summary>
    [Pure]
    public static T DisableWait<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInitSettings.Wait"/></em></p>
    ///   <p>Block until Tiller is running and ready to receive requests.</p>
    /// </summary>
    [Pure]
    public static T ToggleWait<T>(this T toolSettings) where T : HelmInitSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = !toolSettings.Wait;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmInspectSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmInspectSettingsExtensions
{
    #region CaFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectSettings.CaFile"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CaFile = caFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectSettings.CaFile"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetCaFile<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CaFile = null;
        return toolSettings;
    }
    #endregion
    #region CertFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectSettings.CertFile"/></em></p>
    ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
    /// </summary>
    [Pure]
    public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CertFile = certFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectSettings.CertFile"/></em></p>
    ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
    /// </summary>
    [Pure]
    public static T ResetCertFile<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CertFile = null;
        return toolSettings;
    }
    #endregion
    #region Devel
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T SetDevel<T>(this T toolSettings, bool? devel) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = devel;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T ResetDevel<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInspectSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T EnableDevel<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInspectSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T DisableDevel<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInspectSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T ToggleDevel<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = !toolSettings.Devel;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectSettings.Help"/></em></p>
    ///   <p>Help for inspect.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectSettings.Help"/></em></p>
    ///   <p>Help for inspect.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInspectSettings.Help"/></em></p>
    ///   <p>Help for inspect.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInspectSettings.Help"/></em></p>
    ///   <p>Help for inspect.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInspectSettings.Help"/></em></p>
    ///   <p>Help for inspect.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region KeyFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectSettings.KeyFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL key file.</p>
    /// </summary>
    [Pure]
    public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KeyFile = keyFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectSettings.KeyFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL key file.</p>
    /// </summary>
    [Pure]
    public static T ResetKeyFile<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KeyFile = null;
        return toolSettings;
    }
    #endregion
    #region Keyring
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectSettings.Keyring"/></em></p>
    ///   <p>Path to the keyring containing public verification keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = keyring;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectSettings.Keyring"/></em></p>
    ///   <p>Path to the keyring containing public verification keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T ResetKeyring<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = null;
        return toolSettings;
    }
    #endregion
    #region Password
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectSettings.Password"/></em></p>
    ///   <p>Chart repository password where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Password = password;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectSettings.Password"/></em></p>
    ///   <p>Chart repository password where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetPassword<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Password = null;
        return toolSettings;
    }
    #endregion
    #region Repo
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectSettings.Repo"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetRepo<T>(this T toolSettings, string repo) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Repo = repo;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectSettings.Repo"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetRepo<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Repo = null;
        return toolSettings;
    }
    #endregion
    #region Username
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectSettings.Username"/></em></p>
    ///   <p>Chart repository username where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetUsername<T>(this T toolSettings, string username) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Username = username;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectSettings.Username"/></em></p>
    ///   <p>Chart repository username where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetUsername<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Username = null;
        return toolSettings;
    }
    #endregion
    #region Verify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = verify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T ResetVerify<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInspectSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T EnableVerify<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInspectSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T DisableVerify<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInspectSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T ToggleVerify<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = !toolSettings.Verify;
        return toolSettings;
    }
    #endregion
    #region Version
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectSettings.Version"/></em></p>
    ///   <p>Version of the chart. By default, the newest chart is shown.</p>
    /// </summary>
    [Pure]
    public static T SetVersion<T>(this T toolSettings, string version) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = version;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectSettings.Version"/></em></p>
    ///   <p>Version of the chart. By default, the newest chart is shown.</p>
    /// </summary>
    [Pure]
    public static T ResetVersion<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = null;
        return toolSettings;
    }
    #endregion
    #region Chart
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectSettings.Chart"/></em></p>
    ///   <p>The name of the chart to inspect.</p>
    /// </summary>
    [Pure]
    public static T SetChart<T>(this T toolSettings, string chart) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = chart;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectSettings.Chart"/></em></p>
    ///   <p>The name of the chart to inspect.</p>
    /// </summary>
    [Pure]
    public static T ResetChart<T>(this T toolSettings) where T : HelmInspectSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmInspectChartSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmInspectChartSettingsExtensions
{
    #region CaFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectChartSettings.CaFile"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CaFile = caFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectChartSettings.CaFile"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetCaFile<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CaFile = null;
        return toolSettings;
    }
    #endregion
    #region CertFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectChartSettings.CertFile"/></em></p>
    ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
    /// </summary>
    [Pure]
    public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CertFile = certFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectChartSettings.CertFile"/></em></p>
    ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
    /// </summary>
    [Pure]
    public static T ResetCertFile<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CertFile = null;
        return toolSettings;
    }
    #endregion
    #region Devel
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectChartSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T SetDevel<T>(this T toolSettings, bool? devel) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = devel;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectChartSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T ResetDevel<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInspectChartSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T EnableDevel<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInspectChartSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T DisableDevel<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInspectChartSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T ToggleDevel<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = !toolSettings.Devel;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectChartSettings.Help"/></em></p>
    ///   <p>Help for chart.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectChartSettings.Help"/></em></p>
    ///   <p>Help for chart.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInspectChartSettings.Help"/></em></p>
    ///   <p>Help for chart.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInspectChartSettings.Help"/></em></p>
    ///   <p>Help for chart.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInspectChartSettings.Help"/></em></p>
    ///   <p>Help for chart.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region KeyFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectChartSettings.KeyFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL key file.</p>
    /// </summary>
    [Pure]
    public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KeyFile = keyFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectChartSettings.KeyFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL key file.</p>
    /// </summary>
    [Pure]
    public static T ResetKeyFile<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KeyFile = null;
        return toolSettings;
    }
    #endregion
    #region Keyring
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectChartSettings.Keyring"/></em></p>
    ///   <p>Path to the keyring containing public verification keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = keyring;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectChartSettings.Keyring"/></em></p>
    ///   <p>Path to the keyring containing public verification keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T ResetKeyring<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = null;
        return toolSettings;
    }
    #endregion
    #region Password
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectChartSettings.Password"/></em></p>
    ///   <p>Chart repository password where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Password = password;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectChartSettings.Password"/></em></p>
    ///   <p>Chart repository password where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetPassword<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Password = null;
        return toolSettings;
    }
    #endregion
    #region Repo
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectChartSettings.Repo"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetRepo<T>(this T toolSettings, string repo) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Repo = repo;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectChartSettings.Repo"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetRepo<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Repo = null;
        return toolSettings;
    }
    #endregion
    #region Username
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectChartSettings.Username"/></em></p>
    ///   <p>Chart repository username where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetUsername<T>(this T toolSettings, string username) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Username = username;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectChartSettings.Username"/></em></p>
    ///   <p>Chart repository username where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetUsername<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Username = null;
        return toolSettings;
    }
    #endregion
    #region Verify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectChartSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = verify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectChartSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T ResetVerify<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInspectChartSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T EnableVerify<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInspectChartSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T DisableVerify<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInspectChartSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T ToggleVerify<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = !toolSettings.Verify;
        return toolSettings;
    }
    #endregion
    #region Version
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectChartSettings.Version"/></em></p>
    ///   <p>Version of the chart. By default, the newest chart is shown.</p>
    /// </summary>
    [Pure]
    public static T SetVersion<T>(this T toolSettings, string version) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = version;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectChartSettings.Version"/></em></p>
    ///   <p>Version of the chart. By default, the newest chart is shown.</p>
    /// </summary>
    [Pure]
    public static T ResetVersion<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = null;
        return toolSettings;
    }
    #endregion
    #region Chart
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectChartSettings.Chart"/></em></p>
    ///   <p>The name of the chart to inspect.</p>
    /// </summary>
    [Pure]
    public static T SetChart<T>(this T toolSettings, string chart) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = chart;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectChartSettings.Chart"/></em></p>
    ///   <p>The name of the chart to inspect.</p>
    /// </summary>
    [Pure]
    public static T ResetChart<T>(this T toolSettings) where T : HelmInspectChartSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmInspectReadmeSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmInspectReadmeSettingsExtensions
{
    #region CaFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectReadmeSettings.CaFile"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CaFile = caFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectReadmeSettings.CaFile"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetCaFile<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CaFile = null;
        return toolSettings;
    }
    #endregion
    #region CertFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectReadmeSettings.CertFile"/></em></p>
    ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
    /// </summary>
    [Pure]
    public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CertFile = certFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectReadmeSettings.CertFile"/></em></p>
    ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
    /// </summary>
    [Pure]
    public static T ResetCertFile<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CertFile = null;
        return toolSettings;
    }
    #endregion
    #region Devel
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectReadmeSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T SetDevel<T>(this T toolSettings, bool? devel) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = devel;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectReadmeSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T ResetDevel<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInspectReadmeSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T EnableDevel<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInspectReadmeSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T DisableDevel<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInspectReadmeSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T ToggleDevel<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = !toolSettings.Devel;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectReadmeSettings.Help"/></em></p>
    ///   <p>Help for readme.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectReadmeSettings.Help"/></em></p>
    ///   <p>Help for readme.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInspectReadmeSettings.Help"/></em></p>
    ///   <p>Help for readme.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInspectReadmeSettings.Help"/></em></p>
    ///   <p>Help for readme.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInspectReadmeSettings.Help"/></em></p>
    ///   <p>Help for readme.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region KeyFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectReadmeSettings.KeyFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL key file.</p>
    /// </summary>
    [Pure]
    public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KeyFile = keyFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectReadmeSettings.KeyFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL key file.</p>
    /// </summary>
    [Pure]
    public static T ResetKeyFile<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KeyFile = null;
        return toolSettings;
    }
    #endregion
    #region Keyring
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectReadmeSettings.Keyring"/></em></p>
    ///   <p>Path to the keyring containing public verification keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = keyring;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectReadmeSettings.Keyring"/></em></p>
    ///   <p>Path to the keyring containing public verification keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T ResetKeyring<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = null;
        return toolSettings;
    }
    #endregion
    #region Repo
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectReadmeSettings.Repo"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetRepo<T>(this T toolSettings, string repo) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Repo = repo;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectReadmeSettings.Repo"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetRepo<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Repo = null;
        return toolSettings;
    }
    #endregion
    #region Verify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectReadmeSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = verify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectReadmeSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T ResetVerify<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInspectReadmeSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T EnableVerify<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInspectReadmeSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T DisableVerify<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInspectReadmeSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T ToggleVerify<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = !toolSettings.Verify;
        return toolSettings;
    }
    #endregion
    #region Version
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectReadmeSettings.Version"/></em></p>
    ///   <p>Version of the chart. By default, the newest chart is shown.</p>
    /// </summary>
    [Pure]
    public static T SetVersion<T>(this T toolSettings, string version) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = version;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectReadmeSettings.Version"/></em></p>
    ///   <p>Version of the chart. By default, the newest chart is shown.</p>
    /// </summary>
    [Pure]
    public static T ResetVersion<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = null;
        return toolSettings;
    }
    #endregion
    #region Chart
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectReadmeSettings.Chart"/></em></p>
    ///   <p>The name of the chart to inspect.</p>
    /// </summary>
    [Pure]
    public static T SetChart<T>(this T toolSettings, string chart) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = chart;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectReadmeSettings.Chart"/></em></p>
    ///   <p>The name of the chart to inspect.</p>
    /// </summary>
    [Pure]
    public static T ResetChart<T>(this T toolSettings) where T : HelmInspectReadmeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmInspectValuesSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmInspectValuesSettingsExtensions
{
    #region CaFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectValuesSettings.CaFile"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CaFile = caFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectValuesSettings.CaFile"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetCaFile<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CaFile = null;
        return toolSettings;
    }
    #endregion
    #region CertFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectValuesSettings.CertFile"/></em></p>
    ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
    /// </summary>
    [Pure]
    public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CertFile = certFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectValuesSettings.CertFile"/></em></p>
    ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
    /// </summary>
    [Pure]
    public static T ResetCertFile<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CertFile = null;
        return toolSettings;
    }
    #endregion
    #region Devel
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectValuesSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T SetDevel<T>(this T toolSettings, bool? devel) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = devel;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectValuesSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T ResetDevel<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInspectValuesSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T EnableDevel<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInspectValuesSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T DisableDevel<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInspectValuesSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T ToggleDevel<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = !toolSettings.Devel;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectValuesSettings.Help"/></em></p>
    ///   <p>Help for values.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectValuesSettings.Help"/></em></p>
    ///   <p>Help for values.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInspectValuesSettings.Help"/></em></p>
    ///   <p>Help for values.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInspectValuesSettings.Help"/></em></p>
    ///   <p>Help for values.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInspectValuesSettings.Help"/></em></p>
    ///   <p>Help for values.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region KeyFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectValuesSettings.KeyFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL key file.</p>
    /// </summary>
    [Pure]
    public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KeyFile = keyFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectValuesSettings.KeyFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL key file.</p>
    /// </summary>
    [Pure]
    public static T ResetKeyFile<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KeyFile = null;
        return toolSettings;
    }
    #endregion
    #region Keyring
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectValuesSettings.Keyring"/></em></p>
    ///   <p>Path to the keyring containing public verification keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = keyring;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectValuesSettings.Keyring"/></em></p>
    ///   <p>Path to the keyring containing public verification keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T ResetKeyring<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = null;
        return toolSettings;
    }
    #endregion
    #region Password
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectValuesSettings.Password"/></em></p>
    ///   <p>Chart repository password where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Password = password;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectValuesSettings.Password"/></em></p>
    ///   <p>Chart repository password where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetPassword<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Password = null;
        return toolSettings;
    }
    #endregion
    #region Repo
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectValuesSettings.Repo"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetRepo<T>(this T toolSettings, string repo) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Repo = repo;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectValuesSettings.Repo"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetRepo<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Repo = null;
        return toolSettings;
    }
    #endregion
    #region Username
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectValuesSettings.Username"/></em></p>
    ///   <p>Chart repository username where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetUsername<T>(this T toolSettings, string username) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Username = username;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectValuesSettings.Username"/></em></p>
    ///   <p>Chart repository username where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetUsername<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Username = null;
        return toolSettings;
    }
    #endregion
    #region Verify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectValuesSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = verify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectValuesSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T ResetVerify<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInspectValuesSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T EnableVerify<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInspectValuesSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T DisableVerify<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInspectValuesSettings.Verify"/></em></p>
    ///   <p>Verify the provenance data for this chart.</p>
    /// </summary>
    [Pure]
    public static T ToggleVerify<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = !toolSettings.Verify;
        return toolSettings;
    }
    #endregion
    #region Version
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectValuesSettings.Version"/></em></p>
    ///   <p>Version of the chart. By default, the newest chart is shown.</p>
    /// </summary>
    [Pure]
    public static T SetVersion<T>(this T toolSettings, string version) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = version;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectValuesSettings.Version"/></em></p>
    ///   <p>Version of the chart. By default, the newest chart is shown.</p>
    /// </summary>
    [Pure]
    public static T ResetVersion<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = null;
        return toolSettings;
    }
    #endregion
    #region Chart
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInspectValuesSettings.Chart"/></em></p>
    ///   <p>The name of the chart to inspect.</p>
    /// </summary>
    [Pure]
    public static T SetChart<T>(this T toolSettings, string chart) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = chart;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInspectValuesSettings.Chart"/></em></p>
    ///   <p>The name of the chart to inspect.</p>
    /// </summary>
    [Pure]
    public static T ResetChart<T>(this T toolSettings) where T : HelmInspectValuesSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmInstallSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmInstallSettingsExtensions
{
    #region Atomic
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Atomic"/></em></p>
    ///   <p>If set, installation process purges chart on fail, also sets --wait flag.</p>
    /// </summary>
    [Pure]
    public static T SetAtomic<T>(this T toolSettings, bool? atomic) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Atomic = atomic;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Atomic"/></em></p>
    ///   <p>If set, installation process purges chart on fail, also sets --wait flag.</p>
    /// </summary>
    [Pure]
    public static T ResetAtomic<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Atomic = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInstallSettings.Atomic"/></em></p>
    ///   <p>If set, installation process purges chart on fail, also sets --wait flag.</p>
    /// </summary>
    [Pure]
    public static T EnableAtomic<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Atomic = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInstallSettings.Atomic"/></em></p>
    ///   <p>If set, installation process purges chart on fail, also sets --wait flag.</p>
    /// </summary>
    [Pure]
    public static T DisableAtomic<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Atomic = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInstallSettings.Atomic"/></em></p>
    ///   <p>If set, installation process purges chart on fail, also sets --wait flag.</p>
    /// </summary>
    [Pure]
    public static T ToggleAtomic<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Atomic = !toolSettings.Atomic;
        return toolSettings;
    }
    #endregion
    #region CaFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.CaFile"/></em></p>
    ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
    /// </summary>
    [Pure]
    public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CaFile = caFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.CaFile"/></em></p>
    ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
    /// </summary>
    [Pure]
    public static T ResetCaFile<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CaFile = null;
        return toolSettings;
    }
    #endregion
    #region CertFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.CertFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL certificate file.</p>
    /// </summary>
    [Pure]
    public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CertFile = certFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.CertFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL certificate file.</p>
    /// </summary>
    [Pure]
    public static T ResetCertFile<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CertFile = null;
        return toolSettings;
    }
    #endregion
    #region DepUp
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.DepUp"/></em></p>
    ///   <p>Run helm dependency update before installing the chart.</p>
    /// </summary>
    [Pure]
    public static T SetDepUp<T>(this T toolSettings, bool? depUp) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DepUp = depUp;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.DepUp"/></em></p>
    ///   <p>Run helm dependency update before installing the chart.</p>
    /// </summary>
    [Pure]
    public static T ResetDepUp<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DepUp = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInstallSettings.DepUp"/></em></p>
    ///   <p>Run helm dependency update before installing the chart.</p>
    /// </summary>
    [Pure]
    public static T EnableDepUp<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DepUp = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInstallSettings.DepUp"/></em></p>
    ///   <p>Run helm dependency update before installing the chart.</p>
    /// </summary>
    [Pure]
    public static T DisableDepUp<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DepUp = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInstallSettings.DepUp"/></em></p>
    ///   <p>Run helm dependency update before installing the chart.</p>
    /// </summary>
    [Pure]
    public static T ToggleDepUp<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DepUp = !toolSettings.DepUp;
        return toolSettings;
    }
    #endregion
    #region Description
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Description"/></em></p>
    ///   <p>Specify a description for the release.</p>
    /// </summary>
    [Pure]
    public static T SetDescription<T>(this T toolSettings, string description) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Description = description;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Description"/></em></p>
    ///   <p>Specify a description for the release.</p>
    /// </summary>
    [Pure]
    public static T ResetDescription<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Description = null;
        return toolSettings;
    }
    #endregion
    #region Devel
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T SetDevel<T>(this T toolSettings, bool? devel) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = devel;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T ResetDevel<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInstallSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T EnableDevel<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInstallSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T DisableDevel<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInstallSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T ToggleDevel<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = !toolSettings.Devel;
        return toolSettings;
    }
    #endregion
    #region DryRun
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.DryRun"/></em></p>
    ///   <p>Simulate an install.</p>
    /// </summary>
    [Pure]
    public static T SetDryRun<T>(this T toolSettings, bool? dryRun) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = dryRun;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.DryRun"/></em></p>
    ///   <p>Simulate an install.</p>
    /// </summary>
    [Pure]
    public static T ResetDryRun<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInstallSettings.DryRun"/></em></p>
    ///   <p>Simulate an install.</p>
    /// </summary>
    [Pure]
    public static T EnableDryRun<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInstallSettings.DryRun"/></em></p>
    ///   <p>Simulate an install.</p>
    /// </summary>
    [Pure]
    public static T DisableDryRun<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInstallSettings.DryRun"/></em></p>
    ///   <p>Simulate an install.</p>
    /// </summary>
    [Pure]
    public static T ToggleDryRun<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = !toolSettings.DryRun;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Help"/></em></p>
    ///   <p>Help for install.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Help"/></em></p>
    ///   <p>Help for install.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInstallSettings.Help"/></em></p>
    ///   <p>Help for install.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInstallSettings.Help"/></em></p>
    ///   <p>Help for install.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInstallSettings.Help"/></em></p>
    ///   <p>Help for install.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region KeyFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.KeyFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL key file.</p>
    /// </summary>
    [Pure]
    public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KeyFile = keyFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.KeyFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL key file.</p>
    /// </summary>
    [Pure]
    public static T ResetKeyFile<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KeyFile = null;
        return toolSettings;
    }
    #endregion
    #region Keyring
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Keyring"/></em></p>
    ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = keyring;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Keyring"/></em></p>
    ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T ResetKeyring<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = null;
        return toolSettings;
    }
    #endregion
    #region Name
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Name"/></em></p>
    ///   <p>Release name. If unspecified, it will autogenerate one for you.</p>
    /// </summary>
    [Pure]
    public static T SetName<T>(this T toolSettings, string name) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Name = name;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Name"/></em></p>
    ///   <p>Release name. If unspecified, it will autogenerate one for you.</p>
    /// </summary>
    [Pure]
    public static T ResetName<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Name = null;
        return toolSettings;
    }
    #endregion
    #region NameTemplate
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.NameTemplate"/></em></p>
    ///   <p>Specify template used to name the release.</p>
    /// </summary>
    [Pure]
    public static T SetNameTemplate<T>(this T toolSettings, string nameTemplate) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NameTemplate = nameTemplate;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.NameTemplate"/></em></p>
    ///   <p>Specify template used to name the release.</p>
    /// </summary>
    [Pure]
    public static T ResetNameTemplate<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NameTemplate = null;
        return toolSettings;
    }
    #endregion
    #region Namespace
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Namespace"/></em></p>
    ///   <p>Namespace to install the release into. Defaults to the current kube config namespace.</p>
    /// </summary>
    [Pure]
    public static T SetNamespace<T>(this T toolSettings, string @namespace) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Namespace = @namespace;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Namespace"/></em></p>
    ///   <p>Namespace to install the release into. Defaults to the current kube config namespace.</p>
    /// </summary>
    [Pure]
    public static T ResetNamespace<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Namespace = null;
        return toolSettings;
    }
    #endregion
    #region NoCrdHook
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.NoCrdHook"/></em></p>
    ///   <p>Prevent CRD hooks from running, but run other hooks.</p>
    /// </summary>
    [Pure]
    public static T SetNoCrdHook<T>(this T toolSettings, bool? noCrdHook) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoCrdHook = noCrdHook;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.NoCrdHook"/></em></p>
    ///   <p>Prevent CRD hooks from running, but run other hooks.</p>
    /// </summary>
    [Pure]
    public static T ResetNoCrdHook<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoCrdHook = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInstallSettings.NoCrdHook"/></em></p>
    ///   <p>Prevent CRD hooks from running, but run other hooks.</p>
    /// </summary>
    [Pure]
    public static T EnableNoCrdHook<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoCrdHook = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInstallSettings.NoCrdHook"/></em></p>
    ///   <p>Prevent CRD hooks from running, but run other hooks.</p>
    /// </summary>
    [Pure]
    public static T DisableNoCrdHook<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoCrdHook = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInstallSettings.NoCrdHook"/></em></p>
    ///   <p>Prevent CRD hooks from running, but run other hooks.</p>
    /// </summary>
    [Pure]
    public static T ToggleNoCrdHook<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoCrdHook = !toolSettings.NoCrdHook;
        return toolSettings;
    }
    #endregion
    #region NoHooks
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.NoHooks"/></em></p>
    ///   <p>Prevent hooks from running during install.</p>
    /// </summary>
    [Pure]
    public static T SetNoHooks<T>(this T toolSettings, bool? noHooks) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = noHooks;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.NoHooks"/></em></p>
    ///   <p>Prevent hooks from running during install.</p>
    /// </summary>
    [Pure]
    public static T ResetNoHooks<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInstallSettings.NoHooks"/></em></p>
    ///   <p>Prevent hooks from running during install.</p>
    /// </summary>
    [Pure]
    public static T EnableNoHooks<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInstallSettings.NoHooks"/></em></p>
    ///   <p>Prevent hooks from running during install.</p>
    /// </summary>
    [Pure]
    public static T DisableNoHooks<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInstallSettings.NoHooks"/></em></p>
    ///   <p>Prevent hooks from running during install.</p>
    /// </summary>
    [Pure]
    public static T ToggleNoHooks<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = !toolSettings.NoHooks;
        return toolSettings;
    }
    #endregion
    #region Password
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Password"/></em></p>
    ///   <p>Chart repository password where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Password = password;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Password"/></em></p>
    ///   <p>Chart repository password where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetPassword<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Password = null;
        return toolSettings;
    }
    #endregion
    #region RenderSubchartNotes
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.RenderSubchartNotes"/></em></p>
    ///   <p>Render subchart notes along with the parent.</p>
    /// </summary>
    [Pure]
    public static T SetRenderSubchartNotes<T>(this T toolSettings, bool? renderSubchartNotes) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RenderSubchartNotes = renderSubchartNotes;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.RenderSubchartNotes"/></em></p>
    ///   <p>Render subchart notes along with the parent.</p>
    /// </summary>
    [Pure]
    public static T ResetRenderSubchartNotes<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RenderSubchartNotes = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInstallSettings.RenderSubchartNotes"/></em></p>
    ///   <p>Render subchart notes along with the parent.</p>
    /// </summary>
    [Pure]
    public static T EnableRenderSubchartNotes<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RenderSubchartNotes = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInstallSettings.RenderSubchartNotes"/></em></p>
    ///   <p>Render subchart notes along with the parent.</p>
    /// </summary>
    [Pure]
    public static T DisableRenderSubchartNotes<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RenderSubchartNotes = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInstallSettings.RenderSubchartNotes"/></em></p>
    ///   <p>Render subchart notes along with the parent.</p>
    /// </summary>
    [Pure]
    public static T ToggleRenderSubchartNotes<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RenderSubchartNotes = !toolSettings.RenderSubchartNotes;
        return toolSettings;
    }
    #endregion
    #region Replace
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Replace"/></em></p>
    ///   <p>Re-use the given name, even if that name is already used. This is unsafe in production.</p>
    /// </summary>
    [Pure]
    public static T SetReplace<T>(this T toolSettings, bool? replace) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Replace = replace;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Replace"/></em></p>
    ///   <p>Re-use the given name, even if that name is already used. This is unsafe in production.</p>
    /// </summary>
    [Pure]
    public static T ResetReplace<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Replace = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInstallSettings.Replace"/></em></p>
    ///   <p>Re-use the given name, even if that name is already used. This is unsafe in production.</p>
    /// </summary>
    [Pure]
    public static T EnableReplace<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Replace = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInstallSettings.Replace"/></em></p>
    ///   <p>Re-use the given name, even if that name is already used. This is unsafe in production.</p>
    /// </summary>
    [Pure]
    public static T DisableReplace<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Replace = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInstallSettings.Replace"/></em></p>
    ///   <p>Re-use the given name, even if that name is already used. This is unsafe in production.</p>
    /// </summary>
    [Pure]
    public static T ToggleReplace<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Replace = !toolSettings.Replace;
        return toolSettings;
    }
    #endregion
    #region Repo
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Repo"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetRepo<T>(this T toolSettings, string repo) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Repo = repo;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Repo"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetRepo<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Repo = null;
        return toolSettings;
    }
    #endregion
    #region Set
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Set"/> to a new dictionary</em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetSet<T>(this T toolSettings, IDictionary<string, object> set) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal = set.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmInstallSettings.Set"/></em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T ClearSet<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds a new key-value-pair <see cref="HelmInstallSettings.Set"/></em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T AddSet<T>(this T toolSettings, string setKey, object setValue) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal.Add(setKey, setValue);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes a key-value-pair from <see cref="HelmInstallSettings.Set"/></em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T RemoveSet<T>(this T toolSettings, string setKey) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal.Remove(setKey);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets a key-value-pair in <see cref="HelmInstallSettings.Set"/></em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetSet<T>(this T toolSettings, string setKey, object setValue) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal[setKey] = setValue;
        return toolSettings;
    }
    #endregion
    #region SetFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.SetFile"/> to a new dictionary</em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T SetSetFile<T>(this T toolSettings, IDictionary<string, object> setFile) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal = setFile.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmInstallSettings.SetFile"/></em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T ClearSetFile<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds a new key-value-pair <see cref="HelmInstallSettings.SetFile"/></em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T AddSetFile<T>(this T toolSettings, string setFileKey, object setFileValue) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal.Add(setFileKey, setFileValue);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes a key-value-pair from <see cref="HelmInstallSettings.SetFile"/></em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T RemoveSetFile<T>(this T toolSettings, string setFileKey) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal.Remove(setFileKey);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets a key-value-pair in <see cref="HelmInstallSettings.SetFile"/></em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T SetSetFile<T>(this T toolSettings, string setFileKey, object setFileValue) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal[setFileKey] = setFileValue;
        return toolSettings;
    }
    #endregion
    #region SetString
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.SetString"/> to a new dictionary</em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetSetString<T>(this T toolSettings, IDictionary<string, object> setString) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal = setString.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmInstallSettings.SetString"/></em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T ClearSetString<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds a new key-value-pair <see cref="HelmInstallSettings.SetString"/></em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T AddSetString<T>(this T toolSettings, string setStringKey, object setStringValue) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal.Add(setStringKey, setStringValue);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes a key-value-pair from <see cref="HelmInstallSettings.SetString"/></em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T RemoveSetString<T>(this T toolSettings, string setStringKey) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal.Remove(setStringKey);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets a key-value-pair in <see cref="HelmInstallSettings.SetString"/></em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetSetString<T>(this T toolSettings, string setStringKey, object setStringValue) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal[setStringKey] = setStringValue;
        return toolSettings;
    }
    #endregion
    #region Timeout
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Timeout"/></em></p>
    ///   <p>Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).</p>
    /// </summary>
    [Pure]
    public static T SetTimeout<T>(this T toolSettings, long? timeout) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Timeout = timeout;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Timeout"/></em></p>
    ///   <p>Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).</p>
    /// </summary>
    [Pure]
    public static T ResetTimeout<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Timeout = null;
        return toolSettings;
    }
    #endregion
    #region Tls
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T SetTls<T>(this T toolSettings, bool? tls) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = tls;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ResetTls<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInstallSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T EnableTls<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInstallSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T DisableTls<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInstallSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ToggleTls<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = !toolSettings.Tls;
        return toolSettings;
    }
    #endregion
    #region TlsCaCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCaCert<T>(this T toolSettings, string tlsCaCert) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = tlsCaCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCaCert<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCert<T>(this T toolSettings, string tlsCert) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = tlsCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCert<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsHostname
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T SetTlsHostname<T>(this T toolSettings, string tlsHostname) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = tlsHostname;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsHostname<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = null;
        return toolSettings;
    }
    #endregion
    #region TlsKey
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsKey<T>(this T toolSettings, string tlsKey) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = tlsKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsKey<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = null;
        return toolSettings;
    }
    #endregion
    #region TlsVerify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T SetTlsVerify<T>(this T toolSettings, bool? tlsVerify) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = tlsVerify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsVerify<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInstallSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T EnableTlsVerify<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInstallSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T DisableTlsVerify<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInstallSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ToggleTlsVerify<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = !toolSettings.TlsVerify;
        return toolSettings;
    }
    #endregion
    #region Username
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Username"/></em></p>
    ///   <p>Chart repository username where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetUsername<T>(this T toolSettings, string username) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Username = username;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Username"/></em></p>
    ///   <p>Chart repository username where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetUsername<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Username = null;
        return toolSettings;
    }
    #endregion
    #region Values
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Values"/> to a new list</em></p>
    ///   <p>Specify values in a YAML file or a URL(can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T SetValues<T>(this T toolSettings, params string[] values) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal = values.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Values"/> to a new list</em></p>
    ///   <p>Specify values in a YAML file or a URL(can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T SetValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal = values.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmInstallSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file or a URL(can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T AddValues<T>(this T toolSettings, params string[] values) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal.AddRange(values);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmInstallSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file or a URL(can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T AddValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal.AddRange(values);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmInstallSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file or a URL(can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T ClearValues<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmInstallSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file or a URL(can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T RemoveValues<T>(this T toolSettings, params string[] values) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(values);
        toolSettings.ValuesInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmInstallSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file or a URL(can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T RemoveValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(values);
        toolSettings.ValuesInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region Verify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Verify"/></em></p>
    ///   <p>Verify the package before installing it.</p>
    /// </summary>
    [Pure]
    public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = verify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Verify"/></em></p>
    ///   <p>Verify the package before installing it.</p>
    /// </summary>
    [Pure]
    public static T ResetVerify<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInstallSettings.Verify"/></em></p>
    ///   <p>Verify the package before installing it.</p>
    /// </summary>
    [Pure]
    public static T EnableVerify<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInstallSettings.Verify"/></em></p>
    ///   <p>Verify the package before installing it.</p>
    /// </summary>
    [Pure]
    public static T DisableVerify<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInstallSettings.Verify"/></em></p>
    ///   <p>Verify the package before installing it.</p>
    /// </summary>
    [Pure]
    public static T ToggleVerify<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = !toolSettings.Verify;
        return toolSettings;
    }
    #endregion
    #region Version
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Version"/></em></p>
    ///   <p>Specify the exact chart version to install. If this is not specified, the latest version is installed.</p>
    /// </summary>
    [Pure]
    public static T SetVersion<T>(this T toolSettings, string version) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = version;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Version"/></em></p>
    ///   <p>Specify the exact chart version to install. If this is not specified, the latest version is installed.</p>
    /// </summary>
    [Pure]
    public static T ResetVersion<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = null;
        return toolSettings;
    }
    #endregion
    #region Wait
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Wait"/></em></p>
    ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
    /// </summary>
    [Pure]
    public static T SetWait<T>(this T toolSettings, bool? wait) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = wait;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Wait"/></em></p>
    ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
    /// </summary>
    [Pure]
    public static T ResetWait<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmInstallSettings.Wait"/></em></p>
    ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
    /// </summary>
    [Pure]
    public static T EnableWait<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmInstallSettings.Wait"/></em></p>
    ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
    /// </summary>
    [Pure]
    public static T DisableWait<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmInstallSettings.Wait"/></em></p>
    ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
    /// </summary>
    [Pure]
    public static T ToggleWait<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = !toolSettings.Wait;
        return toolSettings;
    }
    #endregion
    #region Chart
    /// <summary>
    ///   <p><em>Sets <see cref="HelmInstallSettings.Chart"/></em></p>
    ///   <p>The name of the chart to install.</p>
    /// </summary>
    [Pure]
    public static T SetChart<T>(this T toolSettings, string chart) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = chart;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmInstallSettings.Chart"/></em></p>
    ///   <p>The name of the chart to install.</p>
    /// </summary>
    [Pure]
    public static T ResetChart<T>(this T toolSettings) where T : HelmInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmLintSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmLintSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmLintSettings.Help"/></em></p>
    ///   <p>Help for lint.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmLintSettings.Help"/></em></p>
    ///   <p>Help for lint.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmLintSettings.Help"/></em></p>
    ///   <p>Help for lint.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmLintSettings.Help"/></em></p>
    ///   <p>Help for lint.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmLintSettings.Help"/></em></p>
    ///   <p>Help for lint.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Namespace
    /// <summary>
    ///   <p><em>Sets <see cref="HelmLintSettings.Namespace"/></em></p>
    ///   <p>Namespace to put the release into (default "default").</p>
    /// </summary>
    [Pure]
    public static T SetNamespace<T>(this T toolSettings, string @namespace) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Namespace = @namespace;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmLintSettings.Namespace"/></em></p>
    ///   <p>Namespace to put the release into (default "default").</p>
    /// </summary>
    [Pure]
    public static T ResetNamespace<T>(this T toolSettings) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Namespace = null;
        return toolSettings;
    }
    #endregion
    #region Set
    /// <summary>
    ///   <p><em>Sets <see cref="HelmLintSettings.Set"/> to a new dictionary</em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetSet<T>(this T toolSettings, IDictionary<string, object> set) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal = set.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmLintSettings.Set"/></em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T ClearSet<T>(this T toolSettings) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds a new key-value-pair <see cref="HelmLintSettings.Set"/></em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T AddSet<T>(this T toolSettings, string setKey, object setValue) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal.Add(setKey, setValue);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes a key-value-pair from <see cref="HelmLintSettings.Set"/></em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T RemoveSet<T>(this T toolSettings, string setKey) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal.Remove(setKey);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets a key-value-pair in <see cref="HelmLintSettings.Set"/></em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetSet<T>(this T toolSettings, string setKey, object setValue) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal[setKey] = setValue;
        return toolSettings;
    }
    #endregion
    #region SetFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmLintSettings.SetFile"/> to a new dictionary</em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T SetSetFile<T>(this T toolSettings, IDictionary<string, object> setFile) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal = setFile.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmLintSettings.SetFile"/></em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T ClearSetFile<T>(this T toolSettings) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds a new key-value-pair <see cref="HelmLintSettings.SetFile"/></em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T AddSetFile<T>(this T toolSettings, string setFileKey, object setFileValue) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal.Add(setFileKey, setFileValue);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes a key-value-pair from <see cref="HelmLintSettings.SetFile"/></em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T RemoveSetFile<T>(this T toolSettings, string setFileKey) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal.Remove(setFileKey);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets a key-value-pair in <see cref="HelmLintSettings.SetFile"/></em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T SetSetFile<T>(this T toolSettings, string setFileKey, object setFileValue) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal[setFileKey] = setFileValue;
        return toolSettings;
    }
    #endregion
    #region SetString
    /// <summary>
    ///   <p><em>Sets <see cref="HelmLintSettings.SetString"/> to a new dictionary</em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetSetString<T>(this T toolSettings, IDictionary<string, object> setString) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal = setString.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmLintSettings.SetString"/></em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T ClearSetString<T>(this T toolSettings) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds a new key-value-pair <see cref="HelmLintSettings.SetString"/></em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T AddSetString<T>(this T toolSettings, string setStringKey, object setStringValue) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal.Add(setStringKey, setStringValue);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes a key-value-pair from <see cref="HelmLintSettings.SetString"/></em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T RemoveSetString<T>(this T toolSettings, string setStringKey) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal.Remove(setStringKey);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets a key-value-pair in <see cref="HelmLintSettings.SetString"/></em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetSetString<T>(this T toolSettings, string setStringKey, object setStringValue) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal[setStringKey] = setStringValue;
        return toolSettings;
    }
    #endregion
    #region Strict
    /// <summary>
    ///   <p><em>Sets <see cref="HelmLintSettings.Strict"/></em></p>
    ///   <p>Fail on lint warnings.</p>
    /// </summary>
    [Pure]
    public static T SetStrict<T>(this T toolSettings, bool? strict) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Strict = strict;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmLintSettings.Strict"/></em></p>
    ///   <p>Fail on lint warnings.</p>
    /// </summary>
    [Pure]
    public static T ResetStrict<T>(this T toolSettings) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Strict = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmLintSettings.Strict"/></em></p>
    ///   <p>Fail on lint warnings.</p>
    /// </summary>
    [Pure]
    public static T EnableStrict<T>(this T toolSettings) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Strict = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmLintSettings.Strict"/></em></p>
    ///   <p>Fail on lint warnings.</p>
    /// </summary>
    [Pure]
    public static T DisableStrict<T>(this T toolSettings) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Strict = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmLintSettings.Strict"/></em></p>
    ///   <p>Fail on lint warnings.</p>
    /// </summary>
    [Pure]
    public static T ToggleStrict<T>(this T toolSettings) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Strict = !toolSettings.Strict;
        return toolSettings;
    }
    #endregion
    #region Values
    /// <summary>
    ///   <p><em>Sets <see cref="HelmLintSettings.Values"/> to a new list</em></p>
    ///   <p>Specify values in a YAML file (can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T SetValues<T>(this T toolSettings, params string[] values) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal = values.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="HelmLintSettings.Values"/> to a new list</em></p>
    ///   <p>Specify values in a YAML file (can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T SetValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal = values.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmLintSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file (can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T AddValues<T>(this T toolSettings, params string[] values) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal.AddRange(values);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmLintSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file (can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T AddValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal.AddRange(values);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmLintSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file (can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T ClearValues<T>(this T toolSettings) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmLintSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file (can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T RemoveValues<T>(this T toolSettings, params string[] values) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(values);
        toolSettings.ValuesInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmLintSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file (can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T RemoveValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(values);
        toolSettings.ValuesInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region Path
    /// <summary>
    ///   <p><em>Sets <see cref="HelmLintSettings.Path"/></em></p>
    ///   <p>The Path to a chart.</p>
    /// </summary>
    [Pure]
    public static T SetPath<T>(this T toolSettings, string path) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Path = path;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmLintSettings.Path"/></em></p>
    ///   <p>The Path to a chart.</p>
    /// </summary>
    [Pure]
    public static T ResetPath<T>(this T toolSettings) where T : HelmLintSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Path = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmListSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmListSettingsExtensions
{
    #region All
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.All"/></em></p>
    ///   <p>Show all releases, not just the ones marked DEPLOYED.</p>
    /// </summary>
    [Pure]
    public static T SetAll<T>(this T toolSettings, bool? all) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.All = all;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.All"/></em></p>
    ///   <p>Show all releases, not just the ones marked DEPLOYED.</p>
    /// </summary>
    [Pure]
    public static T ResetAll<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.All = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmListSettings.All"/></em></p>
    ///   <p>Show all releases, not just the ones marked DEPLOYED.</p>
    /// </summary>
    [Pure]
    public static T EnableAll<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.All = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmListSettings.All"/></em></p>
    ///   <p>Show all releases, not just the ones marked DEPLOYED.</p>
    /// </summary>
    [Pure]
    public static T DisableAll<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.All = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmListSettings.All"/></em></p>
    ///   <p>Show all releases, not just the ones marked DEPLOYED.</p>
    /// </summary>
    [Pure]
    public static T ToggleAll<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.All = !toolSettings.All;
        return toolSettings;
    }
    #endregion
    #region ChartName
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.ChartName"/></em></p>
    ///   <p>Sort by chart name.</p>
    /// </summary>
    [Pure]
    public static T SetChartName<T>(this T toolSettings, bool? chartName) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ChartName = chartName;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.ChartName"/></em></p>
    ///   <p>Sort by chart name.</p>
    /// </summary>
    [Pure]
    public static T ResetChartName<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ChartName = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmListSettings.ChartName"/></em></p>
    ///   <p>Sort by chart name.</p>
    /// </summary>
    [Pure]
    public static T EnableChartName<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ChartName = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmListSettings.ChartName"/></em></p>
    ///   <p>Sort by chart name.</p>
    /// </summary>
    [Pure]
    public static T DisableChartName<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ChartName = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmListSettings.ChartName"/></em></p>
    ///   <p>Sort by chart name.</p>
    /// </summary>
    [Pure]
    public static T ToggleChartName<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ChartName = !toolSettings.ChartName;
        return toolSettings;
    }
    #endregion
    #region ColWidth
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.ColWidth"/></em></p>
    ///   <p>Specifies the max column width of output (default 60).</p>
    /// </summary>
    [Pure]
    public static T SetColWidth<T>(this T toolSettings, uint? colWidth) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ColWidth = colWidth;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.ColWidth"/></em></p>
    ///   <p>Specifies the max column width of output (default 60).</p>
    /// </summary>
    [Pure]
    public static T ResetColWidth<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ColWidth = null;
        return toolSettings;
    }
    #endregion
    #region Date
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.Date"/></em></p>
    ///   <p>Sort by release date.</p>
    /// </summary>
    [Pure]
    public static T SetDate<T>(this T toolSettings, bool? date) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Date = date;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.Date"/></em></p>
    ///   <p>Sort by release date.</p>
    /// </summary>
    [Pure]
    public static T ResetDate<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Date = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmListSettings.Date"/></em></p>
    ///   <p>Sort by release date.</p>
    /// </summary>
    [Pure]
    public static T EnableDate<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Date = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmListSettings.Date"/></em></p>
    ///   <p>Sort by release date.</p>
    /// </summary>
    [Pure]
    public static T DisableDate<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Date = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmListSettings.Date"/></em></p>
    ///   <p>Sort by release date.</p>
    /// </summary>
    [Pure]
    public static T ToggleDate<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Date = !toolSettings.Date;
        return toolSettings;
    }
    #endregion
    #region Deleted
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.Deleted"/></em></p>
    ///   <p>Show deleted releases.</p>
    /// </summary>
    [Pure]
    public static T SetDeleted<T>(this T toolSettings, bool? deleted) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Deleted = deleted;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.Deleted"/></em></p>
    ///   <p>Show deleted releases.</p>
    /// </summary>
    [Pure]
    public static T ResetDeleted<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Deleted = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmListSettings.Deleted"/></em></p>
    ///   <p>Show deleted releases.</p>
    /// </summary>
    [Pure]
    public static T EnableDeleted<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Deleted = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmListSettings.Deleted"/></em></p>
    ///   <p>Show deleted releases.</p>
    /// </summary>
    [Pure]
    public static T DisableDeleted<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Deleted = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmListSettings.Deleted"/></em></p>
    ///   <p>Show deleted releases.</p>
    /// </summary>
    [Pure]
    public static T ToggleDeleted<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Deleted = !toolSettings.Deleted;
        return toolSettings;
    }
    #endregion
    #region Deleting
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.Deleting"/></em></p>
    ///   <p>Show releases that are currently being deleted.</p>
    /// </summary>
    [Pure]
    public static T SetDeleting<T>(this T toolSettings, bool? deleting) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Deleting = deleting;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.Deleting"/></em></p>
    ///   <p>Show releases that are currently being deleted.</p>
    /// </summary>
    [Pure]
    public static T ResetDeleting<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Deleting = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmListSettings.Deleting"/></em></p>
    ///   <p>Show releases that are currently being deleted.</p>
    /// </summary>
    [Pure]
    public static T EnableDeleting<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Deleting = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmListSettings.Deleting"/></em></p>
    ///   <p>Show releases that are currently being deleted.</p>
    /// </summary>
    [Pure]
    public static T DisableDeleting<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Deleting = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmListSettings.Deleting"/></em></p>
    ///   <p>Show releases that are currently being deleted.</p>
    /// </summary>
    [Pure]
    public static T ToggleDeleting<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Deleting = !toolSettings.Deleting;
        return toolSettings;
    }
    #endregion
    #region Deployed
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.Deployed"/></em></p>
    ///   <p>Show deployed releases. If no other is specified, this will be automatically enabled.</p>
    /// </summary>
    [Pure]
    public static T SetDeployed<T>(this T toolSettings, bool? deployed) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Deployed = deployed;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.Deployed"/></em></p>
    ///   <p>Show deployed releases. If no other is specified, this will be automatically enabled.</p>
    /// </summary>
    [Pure]
    public static T ResetDeployed<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Deployed = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmListSettings.Deployed"/></em></p>
    ///   <p>Show deployed releases. If no other is specified, this will be automatically enabled.</p>
    /// </summary>
    [Pure]
    public static T EnableDeployed<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Deployed = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmListSettings.Deployed"/></em></p>
    ///   <p>Show deployed releases. If no other is specified, this will be automatically enabled.</p>
    /// </summary>
    [Pure]
    public static T DisableDeployed<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Deployed = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmListSettings.Deployed"/></em></p>
    ///   <p>Show deployed releases. If no other is specified, this will be automatically enabled.</p>
    /// </summary>
    [Pure]
    public static T ToggleDeployed<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Deployed = !toolSettings.Deployed;
        return toolSettings;
    }
    #endregion
    #region Failed
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.Failed"/></em></p>
    ///   <p>Show failed releases.</p>
    /// </summary>
    [Pure]
    public static T SetFailed<T>(this T toolSettings, bool? failed) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Failed = failed;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.Failed"/></em></p>
    ///   <p>Show failed releases.</p>
    /// </summary>
    [Pure]
    public static T ResetFailed<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Failed = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmListSettings.Failed"/></em></p>
    ///   <p>Show failed releases.</p>
    /// </summary>
    [Pure]
    public static T EnableFailed<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Failed = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmListSettings.Failed"/></em></p>
    ///   <p>Show failed releases.</p>
    /// </summary>
    [Pure]
    public static T DisableFailed<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Failed = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmListSettings.Failed"/></em></p>
    ///   <p>Show failed releases.</p>
    /// </summary>
    [Pure]
    public static T ToggleFailed<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Failed = !toolSettings.Failed;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Max
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.Max"/></em></p>
    ///   <p>Maximum number of releases to fetch (default 256).</p>
    /// </summary>
    [Pure]
    public static T SetMax<T>(this T toolSettings, long? max) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Max = max;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.Max"/></em></p>
    ///   <p>Maximum number of releases to fetch (default 256).</p>
    /// </summary>
    [Pure]
    public static T ResetMax<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Max = null;
        return toolSettings;
    }
    #endregion
    #region Namespace
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.Namespace"/></em></p>
    ///   <p>Show releases within a specific namespace.</p>
    /// </summary>
    [Pure]
    public static T SetNamespace<T>(this T toolSettings, string @namespace) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Namespace = @namespace;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.Namespace"/></em></p>
    ///   <p>Show releases within a specific namespace.</p>
    /// </summary>
    [Pure]
    public static T ResetNamespace<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Namespace = null;
        return toolSettings;
    }
    #endregion
    #region Offset
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.Offset"/></em></p>
    ///   <p>Next release name in the list, used to offset from start value.</p>
    /// </summary>
    [Pure]
    public static T SetOffset<T>(this T toolSettings, string offset) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Offset = offset;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.Offset"/></em></p>
    ///   <p>Next release name in the list, used to offset from start value.</p>
    /// </summary>
    [Pure]
    public static T ResetOffset<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Offset = null;
        return toolSettings;
    }
    #endregion
    #region Output
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.Output"/></em></p>
    ///   <p>Output the specified format (json or yaml).</p>
    /// </summary>
    [Pure]
    public static T SetOutput<T>(this T toolSettings, HelmOutputFormat output) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = output;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.Output"/></em></p>
    ///   <p>Output the specified format (json or yaml).</p>
    /// </summary>
    [Pure]
    public static T ResetOutput<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = null;
        return toolSettings;
    }
    #endregion
    #region Pending
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.Pending"/></em></p>
    ///   <p>Show pending releases.</p>
    /// </summary>
    [Pure]
    public static T SetPending<T>(this T toolSettings, bool? pending) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Pending = pending;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.Pending"/></em></p>
    ///   <p>Show pending releases.</p>
    /// </summary>
    [Pure]
    public static T ResetPending<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Pending = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmListSettings.Pending"/></em></p>
    ///   <p>Show pending releases.</p>
    /// </summary>
    [Pure]
    public static T EnablePending<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Pending = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmListSettings.Pending"/></em></p>
    ///   <p>Show pending releases.</p>
    /// </summary>
    [Pure]
    public static T DisablePending<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Pending = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmListSettings.Pending"/></em></p>
    ///   <p>Show pending releases.</p>
    /// </summary>
    [Pure]
    public static T TogglePending<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Pending = !toolSettings.Pending;
        return toolSettings;
    }
    #endregion
    #region Reverse
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.Reverse"/></em></p>
    ///   <p>Reverse the sort order.</p>
    /// </summary>
    [Pure]
    public static T SetReverse<T>(this T toolSettings, bool? reverse) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Reverse = reverse;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.Reverse"/></em></p>
    ///   <p>Reverse the sort order.</p>
    /// </summary>
    [Pure]
    public static T ResetReverse<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Reverse = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmListSettings.Reverse"/></em></p>
    ///   <p>Reverse the sort order.</p>
    /// </summary>
    [Pure]
    public static T EnableReverse<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Reverse = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmListSettings.Reverse"/></em></p>
    ///   <p>Reverse the sort order.</p>
    /// </summary>
    [Pure]
    public static T DisableReverse<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Reverse = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmListSettings.Reverse"/></em></p>
    ///   <p>Reverse the sort order.</p>
    /// </summary>
    [Pure]
    public static T ToggleReverse<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Reverse = !toolSettings.Reverse;
        return toolSettings;
    }
    #endregion
    #region Short
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.Short"/></em></p>
    ///   <p>Output short (quiet) listing format.</p>
    /// </summary>
    [Pure]
    public static T SetShort<T>(this T toolSettings, bool? @short) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Short = @short;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.Short"/></em></p>
    ///   <p>Output short (quiet) listing format.</p>
    /// </summary>
    [Pure]
    public static T ResetShort<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Short = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmListSettings.Short"/></em></p>
    ///   <p>Output short (quiet) listing format.</p>
    /// </summary>
    [Pure]
    public static T EnableShort<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Short = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmListSettings.Short"/></em></p>
    ///   <p>Output short (quiet) listing format.</p>
    /// </summary>
    [Pure]
    public static T DisableShort<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Short = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmListSettings.Short"/></em></p>
    ///   <p>Output short (quiet) listing format.</p>
    /// </summary>
    [Pure]
    public static T ToggleShort<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Short = !toolSettings.Short;
        return toolSettings;
    }
    #endregion
    #region Tls
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T SetTls<T>(this T toolSettings, bool? tls) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = tls;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ResetTls<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmListSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T EnableTls<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmListSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T DisableTls<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmListSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ToggleTls<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = !toolSettings.Tls;
        return toolSettings;
    }
    #endregion
    #region TlsCaCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCaCert<T>(this T toolSettings, string tlsCaCert) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = tlsCaCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCaCert<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCert<T>(this T toolSettings, string tlsCert) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = tlsCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCert<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsHostname
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T SetTlsHostname<T>(this T toolSettings, string tlsHostname) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = tlsHostname;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsHostname<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = null;
        return toolSettings;
    }
    #endregion
    #region TlsKey
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsKey<T>(this T toolSettings, string tlsKey) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = tlsKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsKey<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = null;
        return toolSettings;
    }
    #endregion
    #region TlsVerify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T SetTlsVerify<T>(this T toolSettings, bool? tlsVerify) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = tlsVerify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsVerify<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmListSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T EnableTlsVerify<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmListSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T DisableTlsVerify<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmListSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ToggleTlsVerify<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = !toolSettings.TlsVerify;
        return toolSettings;
    }
    #endregion
    #region Filter
    /// <summary>
    ///   <p><em>Sets <see cref="HelmListSettings.Filter"/></em></p>
    ///   <p>The filter to use.</p>
    /// </summary>
    [Pure]
    public static T SetFilter<T>(this T toolSettings, string filter) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Filter = filter;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmListSettings.Filter"/></em></p>
    ///   <p>The filter to use.</p>
    /// </summary>
    [Pure]
    public static T ResetFilter<T>(this T toolSettings) where T : HelmListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Filter = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmPackageSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmPackageSettingsExtensions
{
    #region AppVersion
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPackageSettings.AppVersion"/></em></p>
    ///   <p>Set the appVersion on the chart to this version.</p>
    /// </summary>
    [Pure]
    public static T SetAppVersion<T>(this T toolSettings, string appVersion) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AppVersion = appVersion;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmPackageSettings.AppVersion"/></em></p>
    ///   <p>Set the appVersion on the chart to this version.</p>
    /// </summary>
    [Pure]
    public static T ResetAppVersion<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AppVersion = null;
        return toolSettings;
    }
    #endregion
    #region DependencyUpdate
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPackageSettings.DependencyUpdate"/></em></p>
    ///   <p>Update dependencies from "requirements.yaml" to dir "charts/" before packaging.</p>
    /// </summary>
    [Pure]
    public static T SetDependencyUpdate<T>(this T toolSettings, bool? dependencyUpdate) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DependencyUpdate = dependencyUpdate;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmPackageSettings.DependencyUpdate"/></em></p>
    ///   <p>Update dependencies from "requirements.yaml" to dir "charts/" before packaging.</p>
    /// </summary>
    [Pure]
    public static T ResetDependencyUpdate<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DependencyUpdate = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmPackageSettings.DependencyUpdate"/></em></p>
    ///   <p>Update dependencies from "requirements.yaml" to dir "charts/" before packaging.</p>
    /// </summary>
    [Pure]
    public static T EnableDependencyUpdate<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DependencyUpdate = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmPackageSettings.DependencyUpdate"/></em></p>
    ///   <p>Update dependencies from "requirements.yaml" to dir "charts/" before packaging.</p>
    /// </summary>
    [Pure]
    public static T DisableDependencyUpdate<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DependencyUpdate = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmPackageSettings.DependencyUpdate"/></em></p>
    ///   <p>Update dependencies from "requirements.yaml" to dir "charts/" before packaging.</p>
    /// </summary>
    [Pure]
    public static T ToggleDependencyUpdate<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DependencyUpdate = !toolSettings.DependencyUpdate;
        return toolSettings;
    }
    #endregion
    #region Destination
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPackageSettings.Destination"/></em></p>
    ///   <p>Location to write the chart. (default ".").</p>
    /// </summary>
    [Pure]
    public static T SetDestination<T>(this T toolSettings, string destination) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Destination = destination;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmPackageSettings.Destination"/></em></p>
    ///   <p>Location to write the chart. (default ".").</p>
    /// </summary>
    [Pure]
    public static T ResetDestination<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Destination = null;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPackageSettings.Help"/></em></p>
    ///   <p>Help for package.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmPackageSettings.Help"/></em></p>
    ///   <p>Help for package.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmPackageSettings.Help"/></em></p>
    ///   <p>Help for package.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmPackageSettings.Help"/></em></p>
    ///   <p>Help for package.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmPackageSettings.Help"/></em></p>
    ///   <p>Help for package.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Key
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPackageSettings.Key"/></em></p>
    ///   <p>Name of the key to use when signing. Used if --sign is true.</p>
    /// </summary>
    [Pure]
    public static T SetKey<T>(this T toolSettings, string key) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Key = key;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmPackageSettings.Key"/></em></p>
    ///   <p>Name of the key to use when signing. Used if --sign is true.</p>
    /// </summary>
    [Pure]
    public static T ResetKey<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Key = null;
        return toolSettings;
    }
    #endregion
    #region Keyring
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPackageSettings.Keyring"/></em></p>
    ///   <p>Location of a public keyring (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = keyring;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmPackageSettings.Keyring"/></em></p>
    ///   <p>Location of a public keyring (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T ResetKeyring<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = null;
        return toolSettings;
    }
    #endregion
    #region Save
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPackageSettings.Save"/></em></p>
    ///   <p>Save packaged chart to local chart repository (default true).</p>
    /// </summary>
    [Pure]
    public static T SetSave<T>(this T toolSettings, bool? save) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Save = save;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmPackageSettings.Save"/></em></p>
    ///   <p>Save packaged chart to local chart repository (default true).</p>
    /// </summary>
    [Pure]
    public static T ResetSave<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Save = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmPackageSettings.Save"/></em></p>
    ///   <p>Save packaged chart to local chart repository (default true).</p>
    /// </summary>
    [Pure]
    public static T EnableSave<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Save = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmPackageSettings.Save"/></em></p>
    ///   <p>Save packaged chart to local chart repository (default true).</p>
    /// </summary>
    [Pure]
    public static T DisableSave<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Save = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmPackageSettings.Save"/></em></p>
    ///   <p>Save packaged chart to local chart repository (default true).</p>
    /// </summary>
    [Pure]
    public static T ToggleSave<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Save = !toolSettings.Save;
        return toolSettings;
    }
    #endregion
    #region Sign
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPackageSettings.Sign"/></em></p>
    ///   <p>Use a PGP private key to sign this package.</p>
    /// </summary>
    [Pure]
    public static T SetSign<T>(this T toolSettings, bool? sign) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Sign = sign;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmPackageSettings.Sign"/></em></p>
    ///   <p>Use a PGP private key to sign this package.</p>
    /// </summary>
    [Pure]
    public static T ResetSign<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Sign = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmPackageSettings.Sign"/></em></p>
    ///   <p>Use a PGP private key to sign this package.</p>
    /// </summary>
    [Pure]
    public static T EnableSign<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Sign = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmPackageSettings.Sign"/></em></p>
    ///   <p>Use a PGP private key to sign this package.</p>
    /// </summary>
    [Pure]
    public static T DisableSign<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Sign = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmPackageSettings.Sign"/></em></p>
    ///   <p>Use a PGP private key to sign this package.</p>
    /// </summary>
    [Pure]
    public static T ToggleSign<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Sign = !toolSettings.Sign;
        return toolSettings;
    }
    #endregion
    #region Version
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPackageSettings.Version"/></em></p>
    ///   <p>Set the version on the chart to this semver version.</p>
    /// </summary>
    [Pure]
    public static T SetVersion<T>(this T toolSettings, string version) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = version;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmPackageSettings.Version"/></em></p>
    ///   <p>Set the version on the chart to this semver version.</p>
    /// </summary>
    [Pure]
    public static T ResetVersion<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = null;
        return toolSettings;
    }
    #endregion
    #region ChartPaths
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPackageSettings.ChartPaths"/> to a new list</em></p>
    ///   <p>The paths to the charts to package.</p>
    /// </summary>
    [Pure]
    public static T SetChartPaths<T>(this T toolSettings, params string[] chartPaths) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ChartPathsInternal = chartPaths.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPackageSettings.ChartPaths"/> to a new list</em></p>
    ///   <p>The paths to the charts to package.</p>
    /// </summary>
    [Pure]
    public static T SetChartPaths<T>(this T toolSettings, IEnumerable<string> chartPaths) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ChartPathsInternal = chartPaths.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmPackageSettings.ChartPaths"/></em></p>
    ///   <p>The paths to the charts to package.</p>
    /// </summary>
    [Pure]
    public static T AddChartPaths<T>(this T toolSettings, params string[] chartPaths) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ChartPathsInternal.AddRange(chartPaths);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmPackageSettings.ChartPaths"/></em></p>
    ///   <p>The paths to the charts to package.</p>
    /// </summary>
    [Pure]
    public static T AddChartPaths<T>(this T toolSettings, IEnumerable<string> chartPaths) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ChartPathsInternal.AddRange(chartPaths);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmPackageSettings.ChartPaths"/></em></p>
    ///   <p>The paths to the charts to package.</p>
    /// </summary>
    [Pure]
    public static T ClearChartPaths<T>(this T toolSettings) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ChartPathsInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmPackageSettings.ChartPaths"/></em></p>
    ///   <p>The paths to the charts to package.</p>
    /// </summary>
    [Pure]
    public static T RemoveChartPaths<T>(this T toolSettings, params string[] chartPaths) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(chartPaths);
        toolSettings.ChartPathsInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmPackageSettings.ChartPaths"/></em></p>
    ///   <p>The paths to the charts to package.</p>
    /// </summary>
    [Pure]
    public static T RemoveChartPaths<T>(this T toolSettings, IEnumerable<string> chartPaths) where T : HelmPackageSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(chartPaths);
        toolSettings.ChartPathsInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmPluginInstallSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmPluginInstallSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPluginInstallSettings.Help"/></em></p>
    ///   <p>Help for install.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmPluginInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmPluginInstallSettings.Help"/></em></p>
    ///   <p>Help for install.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmPluginInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmPluginInstallSettings.Help"/></em></p>
    ///   <p>Help for install.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmPluginInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmPluginInstallSettings.Help"/></em></p>
    ///   <p>Help for install.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmPluginInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmPluginInstallSettings.Help"/></em></p>
    ///   <p>Help for install.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmPluginInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Version
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPluginInstallSettings.Version"/></em></p>
    ///   <p>Specify a version constraint. If this is not specified, the latest version is installed.</p>
    /// </summary>
    [Pure]
    public static T SetVersion<T>(this T toolSettings, string version) where T : HelmPluginInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = version;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmPluginInstallSettings.Version"/></em></p>
    ///   <p>Specify a version constraint. If this is not specified, the latest version is installed.</p>
    /// </summary>
    [Pure]
    public static T ResetVersion<T>(this T toolSettings) where T : HelmPluginInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = null;
        return toolSettings;
    }
    #endregion
    #region Options
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPluginInstallSettings.Options"/></em></p>
    /// </summary>
    [Pure]
    public static T SetOptions<T>(this T toolSettings, string options) where T : HelmPluginInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Options = options;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmPluginInstallSettings.Options"/></em></p>
    /// </summary>
    [Pure]
    public static T ResetOptions<T>(this T toolSettings) where T : HelmPluginInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Options = null;
        return toolSettings;
    }
    #endregion
    #region Paths
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPluginInstallSettings.Paths"/> to a new list</em></p>
    ///   <p>List of paths or urls of packages to install.</p>
    /// </summary>
    [Pure]
    public static T SetPaths<T>(this T toolSettings, params string[] paths) where T : HelmPluginInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PathsInternal = paths.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPluginInstallSettings.Paths"/> to a new list</em></p>
    ///   <p>List of paths or urls of packages to install.</p>
    /// </summary>
    [Pure]
    public static T SetPaths<T>(this T toolSettings, IEnumerable<string> paths) where T : HelmPluginInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PathsInternal = paths.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmPluginInstallSettings.Paths"/></em></p>
    ///   <p>List of paths or urls of packages to install.</p>
    /// </summary>
    [Pure]
    public static T AddPaths<T>(this T toolSettings, params string[] paths) where T : HelmPluginInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PathsInternal.AddRange(paths);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmPluginInstallSettings.Paths"/></em></p>
    ///   <p>List of paths or urls of packages to install.</p>
    /// </summary>
    [Pure]
    public static T AddPaths<T>(this T toolSettings, IEnumerable<string> paths) where T : HelmPluginInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PathsInternal.AddRange(paths);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmPluginInstallSettings.Paths"/></em></p>
    ///   <p>List of paths or urls of packages to install.</p>
    /// </summary>
    [Pure]
    public static T ClearPaths<T>(this T toolSettings) where T : HelmPluginInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PathsInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmPluginInstallSettings.Paths"/></em></p>
    ///   <p>List of paths or urls of packages to install.</p>
    /// </summary>
    [Pure]
    public static T RemovePaths<T>(this T toolSettings, params string[] paths) where T : HelmPluginInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(paths);
        toolSettings.PathsInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmPluginInstallSettings.Paths"/></em></p>
    ///   <p>List of paths or urls of packages to install.</p>
    /// </summary>
    [Pure]
    public static T RemovePaths<T>(this T toolSettings, IEnumerable<string> paths) where T : HelmPluginInstallSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(paths);
        toolSettings.PathsInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmPluginListSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmPluginListSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPluginListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmPluginListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmPluginListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmPluginListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmPluginListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmPluginListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmPluginListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmPluginListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmPluginListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmPluginListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmPluginRemoveSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmPluginRemoveSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPluginRemoveSettings.Help"/></em></p>
    ///   <p>Help for remove.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmPluginRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmPluginRemoveSettings.Help"/></em></p>
    ///   <p>Help for remove.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmPluginRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmPluginRemoveSettings.Help"/></em></p>
    ///   <p>Help for remove.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmPluginRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmPluginRemoveSettings.Help"/></em></p>
    ///   <p>Help for remove.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmPluginRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmPluginRemoveSettings.Help"/></em></p>
    ///   <p>Help for remove.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmPluginRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Plugins
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPluginRemoveSettings.Plugins"/> to a new list</em></p>
    ///   <p>List of plugins to remove.</p>
    /// </summary>
    [Pure]
    public static T SetPlugins<T>(this T toolSettings, params string[] plugins) where T : HelmPluginRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PluginsInternal = plugins.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPluginRemoveSettings.Plugins"/> to a new list</em></p>
    ///   <p>List of plugins to remove.</p>
    /// </summary>
    [Pure]
    public static T SetPlugins<T>(this T toolSettings, IEnumerable<string> plugins) where T : HelmPluginRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PluginsInternal = plugins.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmPluginRemoveSettings.Plugins"/></em></p>
    ///   <p>List of plugins to remove.</p>
    /// </summary>
    [Pure]
    public static T AddPlugins<T>(this T toolSettings, params string[] plugins) where T : HelmPluginRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PluginsInternal.AddRange(plugins);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmPluginRemoveSettings.Plugins"/></em></p>
    ///   <p>List of plugins to remove.</p>
    /// </summary>
    [Pure]
    public static T AddPlugins<T>(this T toolSettings, IEnumerable<string> plugins) where T : HelmPluginRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PluginsInternal.AddRange(plugins);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmPluginRemoveSettings.Plugins"/></em></p>
    ///   <p>List of plugins to remove.</p>
    /// </summary>
    [Pure]
    public static T ClearPlugins<T>(this T toolSettings) where T : HelmPluginRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PluginsInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmPluginRemoveSettings.Plugins"/></em></p>
    ///   <p>List of plugins to remove.</p>
    /// </summary>
    [Pure]
    public static T RemovePlugins<T>(this T toolSettings, params string[] plugins) where T : HelmPluginRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(plugins);
        toolSettings.PluginsInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmPluginRemoveSettings.Plugins"/></em></p>
    ///   <p>List of plugins to remove.</p>
    /// </summary>
    [Pure]
    public static T RemovePlugins<T>(this T toolSettings, IEnumerable<string> plugins) where T : HelmPluginRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(plugins);
        toolSettings.PluginsInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmPluginUpdateSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmPluginUpdateSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPluginUpdateSettings.Help"/></em></p>
    ///   <p>Help for update.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmPluginUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmPluginUpdateSettings.Help"/></em></p>
    ///   <p>Help for update.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmPluginUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmPluginUpdateSettings.Help"/></em></p>
    ///   <p>Help for update.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmPluginUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmPluginUpdateSettings.Help"/></em></p>
    ///   <p>Help for update.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmPluginUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmPluginUpdateSettings.Help"/></em></p>
    ///   <p>Help for update.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmPluginUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Plugins
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPluginUpdateSettings.Plugins"/> to a new list</em></p>
    ///   <p>List of plugins to update.</p>
    /// </summary>
    [Pure]
    public static T SetPlugins<T>(this T toolSettings, params string[] plugins) where T : HelmPluginUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PluginsInternal = plugins.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="HelmPluginUpdateSettings.Plugins"/> to a new list</em></p>
    ///   <p>List of plugins to update.</p>
    /// </summary>
    [Pure]
    public static T SetPlugins<T>(this T toolSettings, IEnumerable<string> plugins) where T : HelmPluginUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PluginsInternal = plugins.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmPluginUpdateSettings.Plugins"/></em></p>
    ///   <p>List of plugins to update.</p>
    /// </summary>
    [Pure]
    public static T AddPlugins<T>(this T toolSettings, params string[] plugins) where T : HelmPluginUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PluginsInternal.AddRange(plugins);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmPluginUpdateSettings.Plugins"/></em></p>
    ///   <p>List of plugins to update.</p>
    /// </summary>
    [Pure]
    public static T AddPlugins<T>(this T toolSettings, IEnumerable<string> plugins) where T : HelmPluginUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PluginsInternal.AddRange(plugins);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmPluginUpdateSettings.Plugins"/></em></p>
    ///   <p>List of plugins to update.</p>
    /// </summary>
    [Pure]
    public static T ClearPlugins<T>(this T toolSettings) where T : HelmPluginUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PluginsInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmPluginUpdateSettings.Plugins"/></em></p>
    ///   <p>List of plugins to update.</p>
    /// </summary>
    [Pure]
    public static T RemovePlugins<T>(this T toolSettings, params string[] plugins) where T : HelmPluginUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(plugins);
        toolSettings.PluginsInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmPluginUpdateSettings.Plugins"/></em></p>
    ///   <p>List of plugins to update.</p>
    /// </summary>
    [Pure]
    public static T RemovePlugins<T>(this T toolSettings, IEnumerable<string> plugins) where T : HelmPluginUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(plugins);
        toolSettings.PluginsInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmRepoAddSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmRepoAddSettingsExtensions
{
    #region CaFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoAddSettings.CaFile"/></em></p>
    ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
    /// </summary>
    [Pure]
    public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CaFile = caFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoAddSettings.CaFile"/></em></p>
    ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
    /// </summary>
    [Pure]
    public static T ResetCaFile<T>(this T toolSettings) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CaFile = null;
        return toolSettings;
    }
    #endregion
    #region CertFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoAddSettings.CertFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL certificate file.</p>
    /// </summary>
    [Pure]
    public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CertFile = certFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoAddSettings.CertFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL certificate file.</p>
    /// </summary>
    [Pure]
    public static T ResetCertFile<T>(this T toolSettings) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CertFile = null;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoAddSettings.Help"/></em></p>
    ///   <p>Help for add.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoAddSettings.Help"/></em></p>
    ///   <p>Help for add.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmRepoAddSettings.Help"/></em></p>
    ///   <p>Help for add.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmRepoAddSettings.Help"/></em></p>
    ///   <p>Help for add.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmRepoAddSettings.Help"/></em></p>
    ///   <p>Help for add.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region KeyFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoAddSettings.KeyFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL key file.</p>
    /// </summary>
    [Pure]
    public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KeyFile = keyFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoAddSettings.KeyFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL key file.</p>
    /// </summary>
    [Pure]
    public static T ResetKeyFile<T>(this T toolSettings) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KeyFile = null;
        return toolSettings;
    }
    #endregion
    #region NoUpdate
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoAddSettings.NoUpdate"/></em></p>
    ///   <p>Raise error if repo is already registered.</p>
    /// </summary>
    [Pure]
    public static T SetNoUpdate<T>(this T toolSettings, bool? noUpdate) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoUpdate = noUpdate;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoAddSettings.NoUpdate"/></em></p>
    ///   <p>Raise error if repo is already registered.</p>
    /// </summary>
    [Pure]
    public static T ResetNoUpdate<T>(this T toolSettings) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoUpdate = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmRepoAddSettings.NoUpdate"/></em></p>
    ///   <p>Raise error if repo is already registered.</p>
    /// </summary>
    [Pure]
    public static T EnableNoUpdate<T>(this T toolSettings) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoUpdate = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmRepoAddSettings.NoUpdate"/></em></p>
    ///   <p>Raise error if repo is already registered.</p>
    /// </summary>
    [Pure]
    public static T DisableNoUpdate<T>(this T toolSettings) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoUpdate = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmRepoAddSettings.NoUpdate"/></em></p>
    ///   <p>Raise error if repo is already registered.</p>
    /// </summary>
    [Pure]
    public static T ToggleNoUpdate<T>(this T toolSettings) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoUpdate = !toolSettings.NoUpdate;
        return toolSettings;
    }
    #endregion
    #region Password
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoAddSettings.Password"/></em></p>
    ///   <p>Chart repository password.</p>
    /// </summary>
    [Pure]
    public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Password = password;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoAddSettings.Password"/></em></p>
    ///   <p>Chart repository password.</p>
    /// </summary>
    [Pure]
    public static T ResetPassword<T>(this T toolSettings) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Password = null;
        return toolSettings;
    }
    #endregion
    #region Username
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoAddSettings.Username"/></em></p>
    ///   <p>Chart repository username.</p>
    /// </summary>
    [Pure]
    public static T SetUsername<T>(this T toolSettings, string username) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Username = username;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoAddSettings.Username"/></em></p>
    ///   <p>Chart repository username.</p>
    /// </summary>
    [Pure]
    public static T ResetUsername<T>(this T toolSettings) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Username = null;
        return toolSettings;
    }
    #endregion
    #region Name
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoAddSettings.Name"/></em></p>
    ///   <p>The name of the repository to add.</p>
    /// </summary>
    [Pure]
    public static T SetName<T>(this T toolSettings, string name) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Name = name;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoAddSettings.Name"/></em></p>
    ///   <p>The name of the repository to add.</p>
    /// </summary>
    [Pure]
    public static T ResetName<T>(this T toolSettings) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Name = null;
        return toolSettings;
    }
    #endregion
    #region Url
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoAddSettings.Url"/></em></p>
    ///   <p>The url of the repository to add.</p>
    /// </summary>
    [Pure]
    public static T SetUrl<T>(this T toolSettings, string url) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Url = url;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoAddSettings.Url"/></em></p>
    ///   <p>The url of the repository to add.</p>
    /// </summary>
    [Pure]
    public static T ResetUrl<T>(this T toolSettings) where T : HelmRepoAddSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Url = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmRepoIndexSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmRepoIndexSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoIndexSettings.Help"/></em></p>
    ///   <p>Help for index.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmRepoIndexSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoIndexSettings.Help"/></em></p>
    ///   <p>Help for index.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmRepoIndexSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmRepoIndexSettings.Help"/></em></p>
    ///   <p>Help for index.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmRepoIndexSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmRepoIndexSettings.Help"/></em></p>
    ///   <p>Help for index.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmRepoIndexSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmRepoIndexSettings.Help"/></em></p>
    ///   <p>Help for index.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmRepoIndexSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Merge
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoIndexSettings.Merge"/></em></p>
    ///   <p>Merge the generated index into the given index.</p>
    /// </summary>
    [Pure]
    public static T SetMerge<T>(this T toolSettings, string merge) where T : HelmRepoIndexSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Merge = merge;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoIndexSettings.Merge"/></em></p>
    ///   <p>Merge the generated index into the given index.</p>
    /// </summary>
    [Pure]
    public static T ResetMerge<T>(this T toolSettings) where T : HelmRepoIndexSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Merge = null;
        return toolSettings;
    }
    #endregion
    #region Url
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoIndexSettings.Url"/></em></p>
    ///   <p>Url of chart repository.</p>
    /// </summary>
    [Pure]
    public static T SetUrl<T>(this T toolSettings, string url) where T : HelmRepoIndexSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Url = url;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoIndexSettings.Url"/></em></p>
    ///   <p>Url of chart repository.</p>
    /// </summary>
    [Pure]
    public static T ResetUrl<T>(this T toolSettings) where T : HelmRepoIndexSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Url = null;
        return toolSettings;
    }
    #endregion
    #region Directory
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoIndexSettings.Directory"/></em></p>
    ///   <p>The directory of the repository.</p>
    /// </summary>
    [Pure]
    public static T SetDirectory<T>(this T toolSettings, string directory) where T : HelmRepoIndexSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Directory = directory;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoIndexSettings.Directory"/></em></p>
    ///   <p>The directory of the repository.</p>
    /// </summary>
    [Pure]
    public static T ResetDirectory<T>(this T toolSettings) where T : HelmRepoIndexSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Directory = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmRepoListSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmRepoListSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmRepoListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmRepoListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmRepoListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmRepoListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmRepoListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmRepoListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmRepoListSettings.Help"/></em></p>
    ///   <p>Help for list.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmRepoListSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmRepoRemoveSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmRepoRemoveSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoRemoveSettings.Help"/></em></p>
    ///   <p>Help for remove.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmRepoRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoRemoveSettings.Help"/></em></p>
    ///   <p>Help for remove.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmRepoRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmRepoRemoveSettings.Help"/></em></p>
    ///   <p>Help for remove.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmRepoRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmRepoRemoveSettings.Help"/></em></p>
    ///   <p>Help for remove.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmRepoRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmRepoRemoveSettings.Help"/></em></p>
    ///   <p>Help for remove.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmRepoRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Name
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoRemoveSettings.Name"/></em></p>
    ///   <p>The name of the repository.</p>
    /// </summary>
    [Pure]
    public static T SetName<T>(this T toolSettings, string name) where T : HelmRepoRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Name = name;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoRemoveSettings.Name"/></em></p>
    ///   <p>The name of the repository.</p>
    /// </summary>
    [Pure]
    public static T ResetName<T>(this T toolSettings) where T : HelmRepoRemoveSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Name = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmRepoUpdateSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmRepoUpdateSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoUpdateSettings.Help"/></em></p>
    ///   <p>Help for update.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmRepoUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoUpdateSettings.Help"/></em></p>
    ///   <p>Help for update.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmRepoUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmRepoUpdateSettings.Help"/></em></p>
    ///   <p>Help for update.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmRepoUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmRepoUpdateSettings.Help"/></em></p>
    ///   <p>Help for update.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmRepoUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmRepoUpdateSettings.Help"/></em></p>
    ///   <p>Help for update.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmRepoUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Strict
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRepoUpdateSettings.Strict"/></em></p>
    ///   <p>Fail on update warnings.</p>
    /// </summary>
    [Pure]
    public static T SetStrict<T>(this T toolSettings, bool? strict) where T : HelmRepoUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Strict = strict;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRepoUpdateSettings.Strict"/></em></p>
    ///   <p>Fail on update warnings.</p>
    /// </summary>
    [Pure]
    public static T ResetStrict<T>(this T toolSettings) where T : HelmRepoUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Strict = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmRepoUpdateSettings.Strict"/></em></p>
    ///   <p>Fail on update warnings.</p>
    /// </summary>
    [Pure]
    public static T EnableStrict<T>(this T toolSettings) where T : HelmRepoUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Strict = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmRepoUpdateSettings.Strict"/></em></p>
    ///   <p>Fail on update warnings.</p>
    /// </summary>
    [Pure]
    public static T DisableStrict<T>(this T toolSettings) where T : HelmRepoUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Strict = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmRepoUpdateSettings.Strict"/></em></p>
    ///   <p>Fail on update warnings.</p>
    /// </summary>
    [Pure]
    public static T ToggleStrict<T>(this T toolSettings) where T : HelmRepoUpdateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Strict = !toolSettings.Strict;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmResetSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmResetSettingsExtensions
{
    #region Force
    /// <summary>
    ///   <p><em>Sets <see cref="HelmResetSettings.Force"/></em></p>
    ///   <p>Forces Tiller uninstall even if there are releases installed, or if Tiller is not in ready state. Releases are not deleted.).</p>
    /// </summary>
    [Pure]
    public static T SetForce<T>(this T toolSettings, bool? force) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Force = force;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmResetSettings.Force"/></em></p>
    ///   <p>Forces Tiller uninstall even if there are releases installed, or if Tiller is not in ready state. Releases are not deleted.).</p>
    /// </summary>
    [Pure]
    public static T ResetForce<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Force = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmResetSettings.Force"/></em></p>
    ///   <p>Forces Tiller uninstall even if there are releases installed, or if Tiller is not in ready state. Releases are not deleted.).</p>
    /// </summary>
    [Pure]
    public static T EnableForce<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Force = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmResetSettings.Force"/></em></p>
    ///   <p>Forces Tiller uninstall even if there are releases installed, or if Tiller is not in ready state. Releases are not deleted.).</p>
    /// </summary>
    [Pure]
    public static T DisableForce<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Force = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmResetSettings.Force"/></em></p>
    ///   <p>Forces Tiller uninstall even if there are releases installed, or if Tiller is not in ready state. Releases are not deleted.).</p>
    /// </summary>
    [Pure]
    public static T ToggleForce<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Force = !toolSettings.Force;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmResetSettings.Help"/></em></p>
    ///   <p>Help for reset.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmResetSettings.Help"/></em></p>
    ///   <p>Help for reset.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmResetSettings.Help"/></em></p>
    ///   <p>Help for reset.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmResetSettings.Help"/></em></p>
    ///   <p>Help for reset.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmResetSettings.Help"/></em></p>
    ///   <p>Help for reset.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region RemoveHelmHome
    /// <summary>
    ///   <p><em>Sets <see cref="HelmResetSettings.RemoveHelmHome"/></em></p>
    ///   <p>If set deletes $HELM_HOME.</p>
    /// </summary>
    [Pure]
    public static T SetRemoveHelmHome<T>(this T toolSettings, bool? removeHelmHome) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RemoveHelmHome = removeHelmHome;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmResetSettings.RemoveHelmHome"/></em></p>
    ///   <p>If set deletes $HELM_HOME.</p>
    /// </summary>
    [Pure]
    public static T ResetRemoveHelmHome<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RemoveHelmHome = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmResetSettings.RemoveHelmHome"/></em></p>
    ///   <p>If set deletes $HELM_HOME.</p>
    /// </summary>
    [Pure]
    public static T EnableRemoveHelmHome<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RemoveHelmHome = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmResetSettings.RemoveHelmHome"/></em></p>
    ///   <p>If set deletes $HELM_HOME.</p>
    /// </summary>
    [Pure]
    public static T DisableRemoveHelmHome<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RemoveHelmHome = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmResetSettings.RemoveHelmHome"/></em></p>
    ///   <p>If set deletes $HELM_HOME.</p>
    /// </summary>
    [Pure]
    public static T ToggleRemoveHelmHome<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RemoveHelmHome = !toolSettings.RemoveHelmHome;
        return toolSettings;
    }
    #endregion
    #region Tls
    /// <summary>
    ///   <p><em>Sets <see cref="HelmResetSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T SetTls<T>(this T toolSettings, bool? tls) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = tls;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmResetSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ResetTls<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmResetSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T EnableTls<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmResetSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T DisableTls<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmResetSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ToggleTls<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = !toolSettings.Tls;
        return toolSettings;
    }
    #endregion
    #region TlsCaCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmResetSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCaCert<T>(this T toolSettings, string tlsCaCert) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = tlsCaCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmResetSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCaCert<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmResetSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCert<T>(this T toolSettings, string tlsCert) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = tlsCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmResetSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCert<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsHostname
    /// <summary>
    ///   <p><em>Sets <see cref="HelmResetSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T SetTlsHostname<T>(this T toolSettings, string tlsHostname) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = tlsHostname;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmResetSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsHostname<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = null;
        return toolSettings;
    }
    #endregion
    #region TlsKey
    /// <summary>
    ///   <p><em>Sets <see cref="HelmResetSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsKey<T>(this T toolSettings, string tlsKey) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = tlsKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmResetSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsKey<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = null;
        return toolSettings;
    }
    #endregion
    #region TlsVerify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmResetSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T SetTlsVerify<T>(this T toolSettings, bool? tlsVerify) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = tlsVerify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmResetSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsVerify<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmResetSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T EnableTlsVerify<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmResetSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T DisableTlsVerify<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmResetSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ToggleTlsVerify<T>(this T toolSettings) where T : HelmResetSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = !toolSettings.TlsVerify;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmRollbackSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmRollbackSettingsExtensions
{
    #region Description
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRollbackSettings.Description"/></em></p>
    ///   <p>Specify a description for the release.</p>
    /// </summary>
    [Pure]
    public static T SetDescription<T>(this T toolSettings, string description) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Description = description;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRollbackSettings.Description"/></em></p>
    ///   <p>Specify a description for the release.</p>
    /// </summary>
    [Pure]
    public static T ResetDescription<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Description = null;
        return toolSettings;
    }
    #endregion
    #region DryRun
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRollbackSettings.DryRun"/></em></p>
    ///   <p>Simulate a rollback.</p>
    /// </summary>
    [Pure]
    public static T SetDryRun<T>(this T toolSettings, bool? dryRun) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = dryRun;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRollbackSettings.DryRun"/></em></p>
    ///   <p>Simulate a rollback.</p>
    /// </summary>
    [Pure]
    public static T ResetDryRun<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmRollbackSettings.DryRun"/></em></p>
    ///   <p>Simulate a rollback.</p>
    /// </summary>
    [Pure]
    public static T EnableDryRun<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmRollbackSettings.DryRun"/></em></p>
    ///   <p>Simulate a rollback.</p>
    /// </summary>
    [Pure]
    public static T DisableDryRun<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmRollbackSettings.DryRun"/></em></p>
    ///   <p>Simulate a rollback.</p>
    /// </summary>
    [Pure]
    public static T ToggleDryRun<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = !toolSettings.DryRun;
        return toolSettings;
    }
    #endregion
    #region Force
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRollbackSettings.Force"/></em></p>
    ///   <p>Force resource update through delete/recreate if needed.</p>
    /// </summary>
    [Pure]
    public static T SetForce<T>(this T toolSettings, bool? force) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Force = force;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRollbackSettings.Force"/></em></p>
    ///   <p>Force resource update through delete/recreate if needed.</p>
    /// </summary>
    [Pure]
    public static T ResetForce<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Force = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmRollbackSettings.Force"/></em></p>
    ///   <p>Force resource update through delete/recreate if needed.</p>
    /// </summary>
    [Pure]
    public static T EnableForce<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Force = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmRollbackSettings.Force"/></em></p>
    ///   <p>Force resource update through delete/recreate if needed.</p>
    /// </summary>
    [Pure]
    public static T DisableForce<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Force = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmRollbackSettings.Force"/></em></p>
    ///   <p>Force resource update through delete/recreate if needed.</p>
    /// </summary>
    [Pure]
    public static T ToggleForce<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Force = !toolSettings.Force;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRollbackSettings.Help"/></em></p>
    ///   <p>Help for rollback.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRollbackSettings.Help"/></em></p>
    ///   <p>Help for rollback.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmRollbackSettings.Help"/></em></p>
    ///   <p>Help for rollback.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmRollbackSettings.Help"/></em></p>
    ///   <p>Help for rollback.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmRollbackSettings.Help"/></em></p>
    ///   <p>Help for rollback.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region NoHooks
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRollbackSettings.NoHooks"/></em></p>
    ///   <p>Prevent hooks from running during rollback.</p>
    /// </summary>
    [Pure]
    public static T SetNoHooks<T>(this T toolSettings, bool? noHooks) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = noHooks;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRollbackSettings.NoHooks"/></em></p>
    ///   <p>Prevent hooks from running during rollback.</p>
    /// </summary>
    [Pure]
    public static T ResetNoHooks<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmRollbackSettings.NoHooks"/></em></p>
    ///   <p>Prevent hooks from running during rollback.</p>
    /// </summary>
    [Pure]
    public static T EnableNoHooks<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmRollbackSettings.NoHooks"/></em></p>
    ///   <p>Prevent hooks from running during rollback.</p>
    /// </summary>
    [Pure]
    public static T DisableNoHooks<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmRollbackSettings.NoHooks"/></em></p>
    ///   <p>Prevent hooks from running during rollback.</p>
    /// </summary>
    [Pure]
    public static T ToggleNoHooks<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = !toolSettings.NoHooks;
        return toolSettings;
    }
    #endregion
    #region RecreatePods
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRollbackSettings.RecreatePods"/></em></p>
    ///   <p>Performs pods restart for the resource if applicable.</p>
    /// </summary>
    [Pure]
    public static T SetRecreatePods<T>(this T toolSettings, bool? recreatePods) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RecreatePods = recreatePods;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRollbackSettings.RecreatePods"/></em></p>
    ///   <p>Performs pods restart for the resource if applicable.</p>
    /// </summary>
    [Pure]
    public static T ResetRecreatePods<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RecreatePods = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmRollbackSettings.RecreatePods"/></em></p>
    ///   <p>Performs pods restart for the resource if applicable.</p>
    /// </summary>
    [Pure]
    public static T EnableRecreatePods<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RecreatePods = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmRollbackSettings.RecreatePods"/></em></p>
    ///   <p>Performs pods restart for the resource if applicable.</p>
    /// </summary>
    [Pure]
    public static T DisableRecreatePods<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RecreatePods = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmRollbackSettings.RecreatePods"/></em></p>
    ///   <p>Performs pods restart for the resource if applicable.</p>
    /// </summary>
    [Pure]
    public static T ToggleRecreatePods<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RecreatePods = !toolSettings.RecreatePods;
        return toolSettings;
    }
    #endregion
    #region Timeout
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRollbackSettings.Timeout"/></em></p>
    ///   <p>Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).</p>
    /// </summary>
    [Pure]
    public static T SetTimeout<T>(this T toolSettings, long? timeout) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Timeout = timeout;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRollbackSettings.Timeout"/></em></p>
    ///   <p>Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).</p>
    /// </summary>
    [Pure]
    public static T ResetTimeout<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Timeout = null;
        return toolSettings;
    }
    #endregion
    #region Tls
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRollbackSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T SetTls<T>(this T toolSettings, bool? tls) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = tls;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRollbackSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ResetTls<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmRollbackSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T EnableTls<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmRollbackSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T DisableTls<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmRollbackSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ToggleTls<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = !toolSettings.Tls;
        return toolSettings;
    }
    #endregion
    #region TlsCaCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRollbackSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCaCert<T>(this T toolSettings, string tlsCaCert) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = tlsCaCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRollbackSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCaCert<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRollbackSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCert<T>(this T toolSettings, string tlsCert) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = tlsCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRollbackSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCert<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsHostname
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRollbackSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T SetTlsHostname<T>(this T toolSettings, string tlsHostname) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = tlsHostname;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRollbackSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsHostname<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = null;
        return toolSettings;
    }
    #endregion
    #region TlsKey
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRollbackSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsKey<T>(this T toolSettings, string tlsKey) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = tlsKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRollbackSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsKey<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = null;
        return toolSettings;
    }
    #endregion
    #region TlsVerify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRollbackSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T SetTlsVerify<T>(this T toolSettings, bool? tlsVerify) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = tlsVerify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRollbackSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsVerify<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmRollbackSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T EnableTlsVerify<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmRollbackSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T DisableTlsVerify<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmRollbackSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ToggleTlsVerify<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = !toolSettings.TlsVerify;
        return toolSettings;
    }
    #endregion
    #region Wait
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRollbackSettings.Wait"/></em></p>
    ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
    /// </summary>
    [Pure]
    public static T SetWait<T>(this T toolSettings, bool? wait) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = wait;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRollbackSettings.Wait"/></em></p>
    ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
    /// </summary>
    [Pure]
    public static T ResetWait<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmRollbackSettings.Wait"/></em></p>
    ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
    /// </summary>
    [Pure]
    public static T EnableWait<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmRollbackSettings.Wait"/></em></p>
    ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
    /// </summary>
    [Pure]
    public static T DisableWait<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmRollbackSettings.Wait"/></em></p>
    ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
    /// </summary>
    [Pure]
    public static T ToggleWait<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = !toolSettings.Wait;
        return toolSettings;
    }
    #endregion
    #region Release
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRollbackSettings.Release"/></em></p>
    ///   <p>The name of the release.</p>
    /// </summary>
    [Pure]
    public static T SetRelease<T>(this T toolSettings, string release) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Release = release;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRollbackSettings.Release"/></em></p>
    ///   <p>The name of the release.</p>
    /// </summary>
    [Pure]
    public static T ResetRelease<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Release = null;
        return toolSettings;
    }
    #endregion
    #region Revision
    /// <summary>
    ///   <p><em>Sets <see cref="HelmRollbackSettings.Revision"/></em></p>
    ///   <p>The revison to roll back.</p>
    /// </summary>
    [Pure]
    public static T SetRevision<T>(this T toolSettings, string revision) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Revision = revision;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmRollbackSettings.Revision"/></em></p>
    ///   <p>The revison to roll back.</p>
    /// </summary>
    [Pure]
    public static T ResetRevision<T>(this T toolSettings) where T : HelmRollbackSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Revision = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmSearchSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmSearchSettingsExtensions
{
    #region ColWidth
    /// <summary>
    ///   <p><em>Sets <see cref="HelmSearchSettings.ColWidth"/></em></p>
    ///   <p>Specifies the max column width of output (default 60).</p>
    /// </summary>
    [Pure]
    public static T SetColWidth<T>(this T toolSettings, uint? colWidth) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ColWidth = colWidth;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmSearchSettings.ColWidth"/></em></p>
    ///   <p>Specifies the max column width of output (default 60).</p>
    /// </summary>
    [Pure]
    public static T ResetColWidth<T>(this T toolSettings) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ColWidth = null;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmSearchSettings.Help"/></em></p>
    ///   <p>Help for search.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmSearchSettings.Help"/></em></p>
    ///   <p>Help for search.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmSearchSettings.Help"/></em></p>
    ///   <p>Help for search.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmSearchSettings.Help"/></em></p>
    ///   <p>Help for search.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmSearchSettings.Help"/></em></p>
    ///   <p>Help for search.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Regexp
    /// <summary>
    ///   <p><em>Sets <see cref="HelmSearchSettings.Regexp"/></em></p>
    ///   <p>Use regular expressions for searching.</p>
    /// </summary>
    [Pure]
    public static T SetRegexp<T>(this T toolSettings, bool? regexp) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Regexp = regexp;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmSearchSettings.Regexp"/></em></p>
    ///   <p>Use regular expressions for searching.</p>
    /// </summary>
    [Pure]
    public static T ResetRegexp<T>(this T toolSettings) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Regexp = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmSearchSettings.Regexp"/></em></p>
    ///   <p>Use regular expressions for searching.</p>
    /// </summary>
    [Pure]
    public static T EnableRegexp<T>(this T toolSettings) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Regexp = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmSearchSettings.Regexp"/></em></p>
    ///   <p>Use regular expressions for searching.</p>
    /// </summary>
    [Pure]
    public static T DisableRegexp<T>(this T toolSettings) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Regexp = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmSearchSettings.Regexp"/></em></p>
    ///   <p>Use regular expressions for searching.</p>
    /// </summary>
    [Pure]
    public static T ToggleRegexp<T>(this T toolSettings) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Regexp = !toolSettings.Regexp;
        return toolSettings;
    }
    #endregion
    #region Version
    /// <summary>
    ///   <p><em>Sets <see cref="HelmSearchSettings.Version"/></em></p>
    ///   <p>Search using semantic versioning constraints.</p>
    /// </summary>
    [Pure]
    public static T SetVersion<T>(this T toolSettings, string version) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = version;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmSearchSettings.Version"/></em></p>
    ///   <p>Search using semantic versioning constraints.</p>
    /// </summary>
    [Pure]
    public static T ResetVersion<T>(this T toolSettings) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = null;
        return toolSettings;
    }
    #endregion
    #region Versions
    /// <summary>
    ///   <p><em>Sets <see cref="HelmSearchSettings.Versions"/></em></p>
    ///   <p>Show the long listing, with each version of each chart on its own line.</p>
    /// </summary>
    [Pure]
    public static T SetVersions<T>(this T toolSettings, bool? versions) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Versions = versions;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmSearchSettings.Versions"/></em></p>
    ///   <p>Show the long listing, with each version of each chart on its own line.</p>
    /// </summary>
    [Pure]
    public static T ResetVersions<T>(this T toolSettings) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Versions = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmSearchSettings.Versions"/></em></p>
    ///   <p>Show the long listing, with each version of each chart on its own line.</p>
    /// </summary>
    [Pure]
    public static T EnableVersions<T>(this T toolSettings) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Versions = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmSearchSettings.Versions"/></em></p>
    ///   <p>Show the long listing, with each version of each chart on its own line.</p>
    /// </summary>
    [Pure]
    public static T DisableVersions<T>(this T toolSettings) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Versions = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmSearchSettings.Versions"/></em></p>
    ///   <p>Show the long listing, with each version of each chart on its own line.</p>
    /// </summary>
    [Pure]
    public static T ToggleVersions<T>(this T toolSettings) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Versions = !toolSettings.Versions;
        return toolSettings;
    }
    #endregion
    #region Keyword
    /// <summary>
    ///   <p><em>Sets <see cref="HelmSearchSettings.Keyword"/></em></p>
    ///   <p>The keyword to search for.</p>
    /// </summary>
    [Pure]
    public static T SetKeyword<T>(this T toolSettings, string keyword) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyword = keyword;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmSearchSettings.Keyword"/></em></p>
    ///   <p>The keyword to search for.</p>
    /// </summary>
    [Pure]
    public static T ResetKeyword<T>(this T toolSettings) where T : HelmSearchSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyword = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmServeSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmServeSettingsExtensions
{
    #region Address
    /// <summary>
    ///   <p><em>Sets <see cref="HelmServeSettings.Address"/></em></p>
    ///   <p>Address to listen on (default "127.0.0.1:8879").</p>
    /// </summary>
    [Pure]
    public static T SetAddress<T>(this T toolSettings, string address) where T : HelmServeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Address = address;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmServeSettings.Address"/></em></p>
    ///   <p>Address to listen on (default "127.0.0.1:8879").</p>
    /// </summary>
    [Pure]
    public static T ResetAddress<T>(this T toolSettings) where T : HelmServeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Address = null;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmServeSettings.Help"/></em></p>
    ///   <p>Help for serve.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmServeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmServeSettings.Help"/></em></p>
    ///   <p>Help for serve.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmServeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmServeSettings.Help"/></em></p>
    ///   <p>Help for serve.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmServeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmServeSettings.Help"/></em></p>
    ///   <p>Help for serve.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmServeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmServeSettings.Help"/></em></p>
    ///   <p>Help for serve.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmServeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region RepoPath
    /// <summary>
    ///   <p><em>Sets <see cref="HelmServeSettings.RepoPath"/></em></p>
    ///   <p>Local directory path from which to serve charts.</p>
    /// </summary>
    [Pure]
    public static T SetRepoPath<T>(this T toolSettings, string repoPath) where T : HelmServeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RepoPath = repoPath;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmServeSettings.RepoPath"/></em></p>
    ///   <p>Local directory path from which to serve charts.</p>
    /// </summary>
    [Pure]
    public static T ResetRepoPath<T>(this T toolSettings) where T : HelmServeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RepoPath = null;
        return toolSettings;
    }
    #endregion
    #region Url
    /// <summary>
    ///   <p><em>Sets <see cref="HelmServeSettings.Url"/></em></p>
    ///   <p>External URL of chart repository.</p>
    /// </summary>
    [Pure]
    public static T SetUrl<T>(this T toolSettings, string url) where T : HelmServeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Url = url;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmServeSettings.Url"/></em></p>
    ///   <p>External URL of chart repository.</p>
    /// </summary>
    [Pure]
    public static T ResetUrl<T>(this T toolSettings) where T : HelmServeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Url = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmStatusSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmStatusSettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmStatusSettings.Help"/></em></p>
    ///   <p>Help for status.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmStatusSettings.Help"/></em></p>
    ///   <p>Help for status.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmStatusSettings.Help"/></em></p>
    ///   <p>Help for status.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmStatusSettings.Help"/></em></p>
    ///   <p>Help for status.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmStatusSettings.Help"/></em></p>
    ///   <p>Help for status.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Output
    /// <summary>
    ///   <p><em>Sets <see cref="HelmStatusSettings.Output"/></em></p>
    ///   <p>Output the status in the specified format (json or yaml).</p>
    /// </summary>
    [Pure]
    public static T SetOutput<T>(this T toolSettings, HelmOutputFormat output) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = output;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmStatusSettings.Output"/></em></p>
    ///   <p>Output the status in the specified format (json or yaml).</p>
    /// </summary>
    [Pure]
    public static T ResetOutput<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = null;
        return toolSettings;
    }
    #endregion
    #region Revision
    /// <summary>
    ///   <p><em>Sets <see cref="HelmStatusSettings.Revision"/></em></p>
    ///   <p>If set, display the status of the named release with revision.</p>
    /// </summary>
    [Pure]
    public static T SetRevision<T>(this T toolSettings, int? revision) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Revision = revision;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmStatusSettings.Revision"/></em></p>
    ///   <p>If set, display the status of the named release with revision.</p>
    /// </summary>
    [Pure]
    public static T ResetRevision<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Revision = null;
        return toolSettings;
    }
    #endregion
    #region Tls
    /// <summary>
    ///   <p><em>Sets <see cref="HelmStatusSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T SetTls<T>(this T toolSettings, bool? tls) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = tls;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmStatusSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ResetTls<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmStatusSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T EnableTls<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmStatusSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T DisableTls<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmStatusSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ToggleTls<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = !toolSettings.Tls;
        return toolSettings;
    }
    #endregion
    #region TlsCaCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmStatusSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCaCert<T>(this T toolSettings, string tlsCaCert) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = tlsCaCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmStatusSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCaCert<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmStatusSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCert<T>(this T toolSettings, string tlsCert) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = tlsCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmStatusSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCert<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsHostname
    /// <summary>
    ///   <p><em>Sets <see cref="HelmStatusSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T SetTlsHostname<T>(this T toolSettings, string tlsHostname) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = tlsHostname;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmStatusSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsHostname<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = null;
        return toolSettings;
    }
    #endregion
    #region TlsKey
    /// <summary>
    ///   <p><em>Sets <see cref="HelmStatusSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsKey<T>(this T toolSettings, string tlsKey) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = tlsKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmStatusSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsKey<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = null;
        return toolSettings;
    }
    #endregion
    #region TlsVerify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmStatusSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T SetTlsVerify<T>(this T toolSettings, bool? tlsVerify) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = tlsVerify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmStatusSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsVerify<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmStatusSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T EnableTlsVerify<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmStatusSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T DisableTlsVerify<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmStatusSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ToggleTlsVerify<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = !toolSettings.TlsVerify;
        return toolSettings;
    }
    #endregion
    #region ReleaseName
    /// <summary>
    ///   <p><em>Sets <see cref="HelmStatusSettings.ReleaseName"/></em></p>
    ///   <p>The name of the release to get the status for.</p>
    /// </summary>
    [Pure]
    public static T SetReleaseName<T>(this T toolSettings, string releaseName) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseName = releaseName;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmStatusSettings.ReleaseName"/></em></p>
    ///   <p>The name of the release to get the status for.</p>
    /// </summary>
    [Pure]
    public static T ResetReleaseName<T>(this T toolSettings) where T : HelmStatusSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReleaseName = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmTemplateSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmTemplateSettingsExtensions
{
    #region Execute
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTemplateSettings.Execute"/> to a new dictionary</em></p>
    ///   <p>Only execute the given templates.</p>
    /// </summary>
    [Pure]
    public static T SetExecute<T>(this T toolSettings, IDictionary<string, object> execute) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ExecuteInternal = execute.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmTemplateSettings.Execute"/></em></p>
    ///   <p>Only execute the given templates.</p>
    /// </summary>
    [Pure]
    public static T ClearExecute<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ExecuteInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds a new key-value-pair <see cref="HelmTemplateSettings.Execute"/></em></p>
    ///   <p>Only execute the given templates.</p>
    /// </summary>
    [Pure]
    public static T AddExecute<T>(this T toolSettings, string executeKey, object executeValue) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ExecuteInternal.Add(executeKey, executeValue);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes a key-value-pair from <see cref="HelmTemplateSettings.Execute"/></em></p>
    ///   <p>Only execute the given templates.</p>
    /// </summary>
    [Pure]
    public static T RemoveExecute<T>(this T toolSettings, string executeKey) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ExecuteInternal.Remove(executeKey);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets a key-value-pair in <see cref="HelmTemplateSettings.Execute"/></em></p>
    ///   <p>Only execute the given templates.</p>
    /// </summary>
    [Pure]
    public static T SetExecute<T>(this T toolSettings, string executeKey, object executeValue) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ExecuteInternal[executeKey] = executeValue;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTemplateSettings.Help"/></em></p>
    ///   <p>Help for template.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTemplateSettings.Help"/></em></p>
    ///   <p>Help for template.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmTemplateSettings.Help"/></em></p>
    ///   <p>Help for template.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmTemplateSettings.Help"/></em></p>
    ///   <p>Help for template.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmTemplateSettings.Help"/></em></p>
    ///   <p>Help for template.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region IsUpgrade
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTemplateSettings.IsUpgrade"/></em></p>
    ///   <p>Set .Release.IsUpgrade instead of .Release.IsInstall.</p>
    /// </summary>
    [Pure]
    public static T SetIsUpgrade<T>(this T toolSettings, bool? isUpgrade) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.IsUpgrade = isUpgrade;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTemplateSettings.IsUpgrade"/></em></p>
    ///   <p>Set .Release.IsUpgrade instead of .Release.IsInstall.</p>
    /// </summary>
    [Pure]
    public static T ResetIsUpgrade<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.IsUpgrade = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmTemplateSettings.IsUpgrade"/></em></p>
    ///   <p>Set .Release.IsUpgrade instead of .Release.IsInstall.</p>
    /// </summary>
    [Pure]
    public static T EnableIsUpgrade<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.IsUpgrade = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmTemplateSettings.IsUpgrade"/></em></p>
    ///   <p>Set .Release.IsUpgrade instead of .Release.IsInstall.</p>
    /// </summary>
    [Pure]
    public static T DisableIsUpgrade<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.IsUpgrade = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmTemplateSettings.IsUpgrade"/></em></p>
    ///   <p>Set .Release.IsUpgrade instead of .Release.IsInstall.</p>
    /// </summary>
    [Pure]
    public static T ToggleIsUpgrade<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.IsUpgrade = !toolSettings.IsUpgrade;
        return toolSettings;
    }
    #endregion
    #region KubeVersion
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTemplateSettings.KubeVersion"/></em></p>
    ///   <p>Kubernetes version used as Capabilities.KubeVersion.Major/Minor (default "1.9").</p>
    /// </summary>
    [Pure]
    public static T SetKubeVersion<T>(this T toolSettings, string kubeVersion) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KubeVersion = kubeVersion;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTemplateSettings.KubeVersion"/></em></p>
    ///   <p>Kubernetes version used as Capabilities.KubeVersion.Major/Minor (default "1.9").</p>
    /// </summary>
    [Pure]
    public static T ResetKubeVersion<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KubeVersion = null;
        return toolSettings;
    }
    #endregion
    #region Name
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTemplateSettings.Name"/></em></p>
    ///   <p>Release name (default "release-name").</p>
    /// </summary>
    [Pure]
    public static T SetName<T>(this T toolSettings, string name) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Name = name;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTemplateSettings.Name"/></em></p>
    ///   <p>Release name (default "release-name").</p>
    /// </summary>
    [Pure]
    public static T ResetName<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Name = null;
        return toolSettings;
    }
    #endregion
    #region NameTemplate
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTemplateSettings.NameTemplate"/></em></p>
    ///   <p>Specify template used to name the release.</p>
    /// </summary>
    [Pure]
    public static T SetNameTemplate<T>(this T toolSettings, string nameTemplate) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NameTemplate = nameTemplate;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTemplateSettings.NameTemplate"/></em></p>
    ///   <p>Specify template used to name the release.</p>
    /// </summary>
    [Pure]
    public static T ResetNameTemplate<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NameTemplate = null;
        return toolSettings;
    }
    #endregion
    #region Namespace
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTemplateSettings.Namespace"/></em></p>
    ///   <p>Namespace to install the release into.</p>
    /// </summary>
    [Pure]
    public static T SetNamespace<T>(this T toolSettings, string @namespace) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Namespace = @namespace;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTemplateSettings.Namespace"/></em></p>
    ///   <p>Namespace to install the release into.</p>
    /// </summary>
    [Pure]
    public static T ResetNamespace<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Namespace = null;
        return toolSettings;
    }
    #endregion
    #region Notes
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTemplateSettings.Notes"/></em></p>
    ///   <p>Show the computed NOTES.txt file as well.</p>
    /// </summary>
    [Pure]
    public static T SetNotes<T>(this T toolSettings, bool? notes) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Notes = notes;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTemplateSettings.Notes"/></em></p>
    ///   <p>Show the computed NOTES.txt file as well.</p>
    /// </summary>
    [Pure]
    public static T ResetNotes<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Notes = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmTemplateSettings.Notes"/></em></p>
    ///   <p>Show the computed NOTES.txt file as well.</p>
    /// </summary>
    [Pure]
    public static T EnableNotes<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Notes = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmTemplateSettings.Notes"/></em></p>
    ///   <p>Show the computed NOTES.txt file as well.</p>
    /// </summary>
    [Pure]
    public static T DisableNotes<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Notes = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmTemplateSettings.Notes"/></em></p>
    ///   <p>Show the computed NOTES.txt file as well.</p>
    /// </summary>
    [Pure]
    public static T ToggleNotes<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Notes = !toolSettings.Notes;
        return toolSettings;
    }
    #endregion
    #region OutputDir
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTemplateSettings.OutputDir"/></em></p>
    ///   <p>Writes the executed templates to files in output-dir instead of stdout.</p>
    /// </summary>
    [Pure]
    public static T SetOutputDir<T>(this T toolSettings, string outputDir) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.OutputDir = outputDir;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTemplateSettings.OutputDir"/></em></p>
    ///   <p>Writes the executed templates to files in output-dir instead of stdout.</p>
    /// </summary>
    [Pure]
    public static T ResetOutputDir<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.OutputDir = null;
        return toolSettings;
    }
    #endregion
    #region Set
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTemplateSettings.Set"/> to a new dictionary</em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetSet<T>(this T toolSettings, IDictionary<string, object> set) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal = set.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmTemplateSettings.Set"/></em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T ClearSet<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds a new key-value-pair <see cref="HelmTemplateSettings.Set"/></em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T AddSet<T>(this T toolSettings, string setKey, object setValue) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal.Add(setKey, setValue);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes a key-value-pair from <see cref="HelmTemplateSettings.Set"/></em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T RemoveSet<T>(this T toolSettings, string setKey) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal.Remove(setKey);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets a key-value-pair in <see cref="HelmTemplateSettings.Set"/></em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetSet<T>(this T toolSettings, string setKey, object setValue) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal[setKey] = setValue;
        return toolSettings;
    }
    #endregion
    #region SetFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTemplateSettings.SetFile"/> to a new dictionary</em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T SetSetFile<T>(this T toolSettings, IDictionary<string, object> setFile) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal = setFile.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmTemplateSettings.SetFile"/></em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T ClearSetFile<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds a new key-value-pair <see cref="HelmTemplateSettings.SetFile"/></em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T AddSetFile<T>(this T toolSettings, string setFileKey, object setFileValue) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal.Add(setFileKey, setFileValue);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes a key-value-pair from <see cref="HelmTemplateSettings.SetFile"/></em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T RemoveSetFile<T>(this T toolSettings, string setFileKey) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal.Remove(setFileKey);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets a key-value-pair in <see cref="HelmTemplateSettings.SetFile"/></em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T SetSetFile<T>(this T toolSettings, string setFileKey, object setFileValue) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal[setFileKey] = setFileValue;
        return toolSettings;
    }
    #endregion
    #region SetString
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTemplateSettings.SetString"/> to a new dictionary</em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetSetString<T>(this T toolSettings, IDictionary<string, object> setString) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal = setString.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmTemplateSettings.SetString"/></em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T ClearSetString<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds a new key-value-pair <see cref="HelmTemplateSettings.SetString"/></em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T AddSetString<T>(this T toolSettings, string setStringKey, object setStringValue) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal.Add(setStringKey, setStringValue);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes a key-value-pair from <see cref="HelmTemplateSettings.SetString"/></em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T RemoveSetString<T>(this T toolSettings, string setStringKey) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal.Remove(setStringKey);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets a key-value-pair in <see cref="HelmTemplateSettings.SetString"/></em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetSetString<T>(this T toolSettings, string setStringKey, object setStringValue) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal[setStringKey] = setStringValue;
        return toolSettings;
    }
    #endregion
    #region Values
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTemplateSettings.Values"/> to a new list</em></p>
    ///   <p>Specify values in a YAML file (can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T SetValues<T>(this T toolSettings, params string[] values) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal = values.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTemplateSettings.Values"/> to a new list</em></p>
    ///   <p>Specify values in a YAML file (can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T SetValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal = values.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmTemplateSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file (can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T AddValues<T>(this T toolSettings, params string[] values) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal.AddRange(values);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmTemplateSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file (can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T AddValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal.AddRange(values);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmTemplateSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file (can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T ClearValues<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmTemplateSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file (can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T RemoveValues<T>(this T toolSettings, params string[] values) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(values);
        toolSettings.ValuesInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmTemplateSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file (can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T RemoveValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(values);
        toolSettings.ValuesInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region Chart
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTemplateSettings.Chart"/></em></p>
    /// </summary>
    [Pure]
    public static T SetChart<T>(this T toolSettings, string chart) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = chart;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTemplateSettings.Chart"/></em></p>
    /// </summary>
    [Pure]
    public static T ResetChart<T>(this T toolSettings) where T : HelmTemplateSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmTestSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmTestSettingsExtensions
{
    #region Cleanup
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTestSettings.Cleanup"/></em></p>
    ///   <p>Delete test pods upon completion.</p>
    /// </summary>
    [Pure]
    public static T SetCleanup<T>(this T toolSettings, bool? cleanup) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Cleanup = cleanup;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTestSettings.Cleanup"/></em></p>
    ///   <p>Delete test pods upon completion.</p>
    /// </summary>
    [Pure]
    public static T ResetCleanup<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Cleanup = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmTestSettings.Cleanup"/></em></p>
    ///   <p>Delete test pods upon completion.</p>
    /// </summary>
    [Pure]
    public static T EnableCleanup<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Cleanup = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmTestSettings.Cleanup"/></em></p>
    ///   <p>Delete test pods upon completion.</p>
    /// </summary>
    [Pure]
    public static T DisableCleanup<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Cleanup = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmTestSettings.Cleanup"/></em></p>
    ///   <p>Delete test pods upon completion.</p>
    /// </summary>
    [Pure]
    public static T ToggleCleanup<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Cleanup = !toolSettings.Cleanup;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTestSettings.Help"/></em></p>
    ///   <p>Help for test.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTestSettings.Help"/></em></p>
    ///   <p>Help for test.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmTestSettings.Help"/></em></p>
    ///   <p>Help for test.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmTestSettings.Help"/></em></p>
    ///   <p>Help for test.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmTestSettings.Help"/></em></p>
    ///   <p>Help for test.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Parallel
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTestSettings.Parallel"/></em></p>
    ///   <p>Run test pods in parallel.</p>
    /// </summary>
    [Pure]
    public static T SetParallel<T>(this T toolSettings, bool? parallel) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Parallel = parallel;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTestSettings.Parallel"/></em></p>
    ///   <p>Run test pods in parallel.</p>
    /// </summary>
    [Pure]
    public static T ResetParallel<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Parallel = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmTestSettings.Parallel"/></em></p>
    ///   <p>Run test pods in parallel.</p>
    /// </summary>
    [Pure]
    public static T EnableParallel<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Parallel = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmTestSettings.Parallel"/></em></p>
    ///   <p>Run test pods in parallel.</p>
    /// </summary>
    [Pure]
    public static T DisableParallel<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Parallel = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmTestSettings.Parallel"/></em></p>
    ///   <p>Run test pods in parallel.</p>
    /// </summary>
    [Pure]
    public static T ToggleParallel<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Parallel = !toolSettings.Parallel;
        return toolSettings;
    }
    #endregion
    #region Timeout
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTestSettings.Timeout"/></em></p>
    ///   <p>Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).</p>
    /// </summary>
    [Pure]
    public static T SetTimeout<T>(this T toolSettings, long? timeout) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Timeout = timeout;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTestSettings.Timeout"/></em></p>
    ///   <p>Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).</p>
    /// </summary>
    [Pure]
    public static T ResetTimeout<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Timeout = null;
        return toolSettings;
    }
    #endregion
    #region Tls
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTestSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T SetTls<T>(this T toolSettings, bool? tls) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = tls;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTestSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ResetTls<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmTestSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T EnableTls<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmTestSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T DisableTls<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmTestSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ToggleTls<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = !toolSettings.Tls;
        return toolSettings;
    }
    #endregion
    #region TlsCaCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTestSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCaCert<T>(this T toolSettings, string tlsCaCert) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = tlsCaCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTestSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCaCert<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTestSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCert<T>(this T toolSettings, string tlsCert) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = tlsCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTestSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCert<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsHostname
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTestSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T SetTlsHostname<T>(this T toolSettings, string tlsHostname) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = tlsHostname;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTestSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsHostname<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = null;
        return toolSettings;
    }
    #endregion
    #region TlsKey
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTestSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsKey<T>(this T toolSettings, string tlsKey) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = tlsKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTestSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsKey<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = null;
        return toolSettings;
    }
    #endregion
    #region TlsVerify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTestSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T SetTlsVerify<T>(this T toolSettings, bool? tlsVerify) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = tlsVerify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTestSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsVerify<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmTestSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T EnableTlsVerify<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmTestSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T DisableTlsVerify<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmTestSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ToggleTlsVerify<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = !toolSettings.TlsVerify;
        return toolSettings;
    }
    #endregion
    #region Release
    /// <summary>
    ///   <p><em>Sets <see cref="HelmTestSettings.Release"/></em></p>
    ///   <p>The name of the release to test.</p>
    /// </summary>
    [Pure]
    public static T SetRelease<T>(this T toolSettings, string release) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Release = release;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmTestSettings.Release"/></em></p>
    ///   <p>The name of the release to test.</p>
    /// </summary>
    [Pure]
    public static T ResetRelease<T>(this T toolSettings) where T : HelmTestSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Release = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmUpgradeSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmUpgradeSettingsExtensions
{
    #region Atomic
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Atomic"/></em></p>
    ///   <p>If set, upgrade process rolls back changes made in case of failed upgrade, also sets --wait flag.</p>
    /// </summary>
    [Pure]
    public static T SetAtomic<T>(this T toolSettings, bool? atomic) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Atomic = atomic;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Atomic"/></em></p>
    ///   <p>If set, upgrade process rolls back changes made in case of failed upgrade, also sets --wait flag.</p>
    /// </summary>
    [Pure]
    public static T ResetAtomic<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Atomic = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmUpgradeSettings.Atomic"/></em></p>
    ///   <p>If set, upgrade process rolls back changes made in case of failed upgrade, also sets --wait flag.</p>
    /// </summary>
    [Pure]
    public static T EnableAtomic<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Atomic = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmUpgradeSettings.Atomic"/></em></p>
    ///   <p>If set, upgrade process rolls back changes made in case of failed upgrade, also sets --wait flag.</p>
    /// </summary>
    [Pure]
    public static T DisableAtomic<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Atomic = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmUpgradeSettings.Atomic"/></em></p>
    ///   <p>If set, upgrade process rolls back changes made in case of failed upgrade, also sets --wait flag.</p>
    /// </summary>
    [Pure]
    public static T ToggleAtomic<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Atomic = !toolSettings.Atomic;
        return toolSettings;
    }
    #endregion
    #region CaFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.CaFile"/></em></p>
    ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
    /// </summary>
    [Pure]
    public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CaFile = caFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.CaFile"/></em></p>
    ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
    /// </summary>
    [Pure]
    public static T ResetCaFile<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CaFile = null;
        return toolSettings;
    }
    #endregion
    #region CertFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.CertFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL certificate file.</p>
    /// </summary>
    [Pure]
    public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CertFile = certFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.CertFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL certificate file.</p>
    /// </summary>
    [Pure]
    public static T ResetCertFile<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CertFile = null;
        return toolSettings;
    }
    #endregion
    #region Description
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Description"/></em></p>
    ///   <p>Specify the description to use for the upgrade, rather than the default.</p>
    /// </summary>
    [Pure]
    public static T SetDescription<T>(this T toolSettings, string description) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Description = description;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Description"/></em></p>
    ///   <p>Specify the description to use for the upgrade, rather than the default.</p>
    /// </summary>
    [Pure]
    public static T ResetDescription<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Description = null;
        return toolSettings;
    }
    #endregion
    #region Devel
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T SetDevel<T>(this T toolSettings, bool? devel) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = devel;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T ResetDevel<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmUpgradeSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T EnableDevel<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmUpgradeSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T DisableDevel<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmUpgradeSettings.Devel"/></em></p>
    ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T ToggleDevel<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Devel = !toolSettings.Devel;
        return toolSettings;
    }
    #endregion
    #region DryRun
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.DryRun"/></em></p>
    ///   <p>Simulate an upgrade.</p>
    /// </summary>
    [Pure]
    public static T SetDryRun<T>(this T toolSettings, bool? dryRun) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = dryRun;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.DryRun"/></em></p>
    ///   <p>Simulate an upgrade.</p>
    /// </summary>
    [Pure]
    public static T ResetDryRun<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmUpgradeSettings.DryRun"/></em></p>
    ///   <p>Simulate an upgrade.</p>
    /// </summary>
    [Pure]
    public static T EnableDryRun<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmUpgradeSettings.DryRun"/></em></p>
    ///   <p>Simulate an upgrade.</p>
    /// </summary>
    [Pure]
    public static T DisableDryRun<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmUpgradeSettings.DryRun"/></em></p>
    ///   <p>Simulate an upgrade.</p>
    /// </summary>
    [Pure]
    public static T ToggleDryRun<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DryRun = !toolSettings.DryRun;
        return toolSettings;
    }
    #endregion
    #region Force
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Force"/></em></p>
    ///   <p>Force resource update through delete/recreate if needed.</p>
    /// </summary>
    [Pure]
    public static T SetForce<T>(this T toolSettings, bool? force) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Force = force;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Force"/></em></p>
    ///   <p>Force resource update through delete/recreate if needed.</p>
    /// </summary>
    [Pure]
    public static T ResetForce<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Force = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmUpgradeSettings.Force"/></em></p>
    ///   <p>Force resource update through delete/recreate if needed.</p>
    /// </summary>
    [Pure]
    public static T EnableForce<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Force = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmUpgradeSettings.Force"/></em></p>
    ///   <p>Force resource update through delete/recreate if needed.</p>
    /// </summary>
    [Pure]
    public static T DisableForce<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Force = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmUpgradeSettings.Force"/></em></p>
    ///   <p>Force resource update through delete/recreate if needed.</p>
    /// </summary>
    [Pure]
    public static T ToggleForce<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Force = !toolSettings.Force;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Help"/></em></p>
    ///   <p>Help for upgrade.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Help"/></em></p>
    ///   <p>Help for upgrade.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmUpgradeSettings.Help"/></em></p>
    ///   <p>Help for upgrade.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmUpgradeSettings.Help"/></em></p>
    ///   <p>Help for upgrade.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmUpgradeSettings.Help"/></em></p>
    ///   <p>Help for upgrade.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Install
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Install"/></em></p>
    ///   <p>If a release by this name doesn't already exist, run an install.</p>
    /// </summary>
    [Pure]
    public static T SetInstall<T>(this T toolSettings, bool? install) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Install = install;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Install"/></em></p>
    ///   <p>If a release by this name doesn't already exist, run an install.</p>
    /// </summary>
    [Pure]
    public static T ResetInstall<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Install = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmUpgradeSettings.Install"/></em></p>
    ///   <p>If a release by this name doesn't already exist, run an install.</p>
    /// </summary>
    [Pure]
    public static T EnableInstall<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Install = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmUpgradeSettings.Install"/></em></p>
    ///   <p>If a release by this name doesn't already exist, run an install.</p>
    /// </summary>
    [Pure]
    public static T DisableInstall<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Install = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmUpgradeSettings.Install"/></em></p>
    ///   <p>If a release by this name doesn't already exist, run an install.</p>
    /// </summary>
    [Pure]
    public static T ToggleInstall<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Install = !toolSettings.Install;
        return toolSettings;
    }
    #endregion
    #region CreateNamespace
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.CreateNamespace"/></em></p>
    ///   <p>If --install is set, create the release namespace if not present.</p>
    /// </summary>
    [Pure]
    public static T SetCreateNamespace<T>(this T toolSettings, bool? createNamespace) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CreateNamespace = createNamespace;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.CreateNamespace"/></em></p>
    ///   <p>If --install is set, create the release namespace if not present.</p>
    /// </summary>
    [Pure]
    public static T ResetCreateNamespace<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CreateNamespace = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmUpgradeSettings.CreateNamespace"/></em></p>
    ///   <p>If --install is set, create the release namespace if not present.</p>
    /// </summary>
    [Pure]
    public static T EnableCreateNamespace<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CreateNamespace = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmUpgradeSettings.CreateNamespace"/></em></p>
    ///   <p>If --install is set, create the release namespace if not present.</p>
    /// </summary>
    [Pure]
    public static T DisableCreateNamespace<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CreateNamespace = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmUpgradeSettings.CreateNamespace"/></em></p>
    ///   <p>If --install is set, create the release namespace if not present.</p>
    /// </summary>
    [Pure]
    public static T ToggleCreateNamespace<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.CreateNamespace = !toolSettings.CreateNamespace;
        return toolSettings;
    }
    #endregion
    #region KeyFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.KeyFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL key file.</p>
    /// </summary>
    [Pure]
    public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KeyFile = keyFile;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.KeyFile"/></em></p>
    ///   <p>Identify HTTPS client using this SSL key file.</p>
    /// </summary>
    [Pure]
    public static T ResetKeyFile<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KeyFile = null;
        return toolSettings;
    }
    #endregion
    #region Keyring
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Keyring"/></em></p>
    ///   <p>Path to the keyring that contains public signing keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = keyring;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Keyring"/></em></p>
    ///   <p>Path to the keyring that contains public signing keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T ResetKeyring<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = null;
        return toolSettings;
    }
    #endregion
    #region Namespace
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Namespace"/></em></p>
    ///   <p>Namespace to install the release into (only used if --install is set). Defaults to the current kube config namespace.</p>
    /// </summary>
    [Pure]
    public static T SetNamespace<T>(this T toolSettings, string @namespace) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Namespace = @namespace;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Namespace"/></em></p>
    ///   <p>Namespace to install the release into (only used if --install is set). Defaults to the current kube config namespace.</p>
    /// </summary>
    [Pure]
    public static T ResetNamespace<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Namespace = null;
        return toolSettings;
    }
    #endregion
    #region NoHooks
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.NoHooks"/></em></p>
    ///   <p>Disable pre/post upgrade hooks.</p>
    /// </summary>
    [Pure]
    public static T SetNoHooks<T>(this T toolSettings, bool? noHooks) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = noHooks;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.NoHooks"/></em></p>
    ///   <p>Disable pre/post upgrade hooks.</p>
    /// </summary>
    [Pure]
    public static T ResetNoHooks<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmUpgradeSettings.NoHooks"/></em></p>
    ///   <p>Disable pre/post upgrade hooks.</p>
    /// </summary>
    [Pure]
    public static T EnableNoHooks<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmUpgradeSettings.NoHooks"/></em></p>
    ///   <p>Disable pre/post upgrade hooks.</p>
    /// </summary>
    [Pure]
    public static T DisableNoHooks<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmUpgradeSettings.NoHooks"/></em></p>
    ///   <p>Disable pre/post upgrade hooks.</p>
    /// </summary>
    [Pure]
    public static T ToggleNoHooks<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NoHooks = !toolSettings.NoHooks;
        return toolSettings;
    }
    #endregion
    #region Password
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Password"/></em></p>
    ///   <p>Chart repository password where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Password = password;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Password"/></em></p>
    ///   <p>Chart repository password where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetPassword<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Password = null;
        return toolSettings;
    }
    #endregion
    #region RecreatePods
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.RecreatePods"/></em></p>
    ///   <p>Performs pods restart for the resource if applicable.</p>
    /// </summary>
    [Pure]
    public static T SetRecreatePods<T>(this T toolSettings, bool? recreatePods) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RecreatePods = recreatePods;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.RecreatePods"/></em></p>
    ///   <p>Performs pods restart for the resource if applicable.</p>
    /// </summary>
    [Pure]
    public static T ResetRecreatePods<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RecreatePods = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmUpgradeSettings.RecreatePods"/></em></p>
    ///   <p>Performs pods restart for the resource if applicable.</p>
    /// </summary>
    [Pure]
    public static T EnableRecreatePods<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RecreatePods = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmUpgradeSettings.RecreatePods"/></em></p>
    ///   <p>Performs pods restart for the resource if applicable.</p>
    /// </summary>
    [Pure]
    public static T DisableRecreatePods<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RecreatePods = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmUpgradeSettings.RecreatePods"/></em></p>
    ///   <p>Performs pods restart for the resource if applicable.</p>
    /// </summary>
    [Pure]
    public static T ToggleRecreatePods<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RecreatePods = !toolSettings.RecreatePods;
        return toolSettings;
    }
    #endregion
    #region RenderSubchartNotes
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></em></p>
    ///   <p>Render subchart notes along with parent.</p>
    /// </summary>
    [Pure]
    public static T SetRenderSubchartNotes<T>(this T toolSettings, bool? renderSubchartNotes) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RenderSubchartNotes = renderSubchartNotes;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></em></p>
    ///   <p>Render subchart notes along with parent.</p>
    /// </summary>
    [Pure]
    public static T ResetRenderSubchartNotes<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RenderSubchartNotes = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></em></p>
    ///   <p>Render subchart notes along with parent.</p>
    /// </summary>
    [Pure]
    public static T EnableRenderSubchartNotes<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RenderSubchartNotes = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></em></p>
    ///   <p>Render subchart notes along with parent.</p>
    /// </summary>
    [Pure]
    public static T DisableRenderSubchartNotes<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RenderSubchartNotes = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></em></p>
    ///   <p>Render subchart notes along with parent.</p>
    /// </summary>
    [Pure]
    public static T ToggleRenderSubchartNotes<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RenderSubchartNotes = !toolSettings.RenderSubchartNotes;
        return toolSettings;
    }
    #endregion
    #region Repo
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Repo"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetRepo<T>(this T toolSettings, string repo) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Repo = repo;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Repo"/></em></p>
    ///   <p>Chart repository url where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetRepo<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Repo = null;
        return toolSettings;
    }
    #endregion
    #region ResetValues
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.ResetValues"/></em></p>
    ///   <p>When upgrading, reset the values to the ones built into the chart.</p>
    /// </summary>
    [Pure]
    public static T SetResetValues<T>(this T toolSettings, bool? resetValues) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ResetValues = resetValues;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.ResetValues"/></em></p>
    ///   <p>When upgrading, reset the values to the ones built into the chart.</p>
    /// </summary>
    [Pure]
    public static T ResetResetValues<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ResetValues = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmUpgradeSettings.ResetValues"/></em></p>
    ///   <p>When upgrading, reset the values to the ones built into the chart.</p>
    /// </summary>
    [Pure]
    public static T EnableResetValues<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ResetValues = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmUpgradeSettings.ResetValues"/></em></p>
    ///   <p>When upgrading, reset the values to the ones built into the chart.</p>
    /// </summary>
    [Pure]
    public static T DisableResetValues<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ResetValues = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmUpgradeSettings.ResetValues"/></em></p>
    ///   <p>When upgrading, reset the values to the ones built into the chart.</p>
    /// </summary>
    [Pure]
    public static T ToggleResetValues<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ResetValues = !toolSettings.ResetValues;
        return toolSettings;
    }
    #endregion
    #region ReuseValues
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.ReuseValues"/></em></p>
    ///   <p>When upgrading, reuse the last release's values and merge in any overrides from the command line via --set and -f. If '--reset-values' is specified, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T SetReuseValues<T>(this T toolSettings, bool? reuseValues) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReuseValues = reuseValues;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.ReuseValues"/></em></p>
    ///   <p>When upgrading, reuse the last release's values and merge in any overrides from the command line via --set and -f. If '--reset-values' is specified, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T ResetReuseValues<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReuseValues = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmUpgradeSettings.ReuseValues"/></em></p>
    ///   <p>When upgrading, reuse the last release's values and merge in any overrides from the command line via --set and -f. If '--reset-values' is specified, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T EnableReuseValues<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReuseValues = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmUpgradeSettings.ReuseValues"/></em></p>
    ///   <p>When upgrading, reuse the last release's values and merge in any overrides from the command line via --set and -f. If '--reset-values' is specified, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T DisableReuseValues<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReuseValues = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmUpgradeSettings.ReuseValues"/></em></p>
    ///   <p>When upgrading, reuse the last release's values and merge in any overrides from the command line via --set and -f. If '--reset-values' is specified, this is ignored.</p>
    /// </summary>
    [Pure]
    public static T ToggleReuseValues<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ReuseValues = !toolSettings.ReuseValues;
        return toolSettings;
    }
    #endregion
    #region Set
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Set"/> to a new dictionary</em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetSet<T>(this T toolSettings, IDictionary<string, object> set) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal = set.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmUpgradeSettings.Set"/></em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T ClearSet<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds a new key-value-pair <see cref="HelmUpgradeSettings.Set"/></em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T AddSet<T>(this T toolSettings, string setKey, object setValue) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal.Add(setKey, setValue);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes a key-value-pair from <see cref="HelmUpgradeSettings.Set"/></em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T RemoveSet<T>(this T toolSettings, string setKey) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal.Remove(setKey);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets a key-value-pair in <see cref="HelmUpgradeSettings.Set"/></em></p>
    ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetSet<T>(this T toolSettings, string setKey, object setValue) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetInternal[setKey] = setValue;
        return toolSettings;
    }
    #endregion
    #region SetFile
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.SetFile"/> to a new dictionary</em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T SetSetFile<T>(this T toolSettings, IDictionary<string, object> setFile) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal = setFile.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmUpgradeSettings.SetFile"/></em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T ClearSetFile<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds a new key-value-pair <see cref="HelmUpgradeSettings.SetFile"/></em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T AddSetFile<T>(this T toolSettings, string setFileKey, object setFileValue) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal.Add(setFileKey, setFileValue);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes a key-value-pair from <see cref="HelmUpgradeSettings.SetFile"/></em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T RemoveSetFile<T>(this T toolSettings, string setFileKey) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal.Remove(setFileKey);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets a key-value-pair in <see cref="HelmUpgradeSettings.SetFile"/></em></p>
    ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
    /// </summary>
    [Pure]
    public static T SetSetFile<T>(this T toolSettings, string setFileKey, object setFileValue) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetFileInternal[setFileKey] = setFileValue;
        return toolSettings;
    }
    #endregion
    #region SetString
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.SetString"/> to a new dictionary</em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetSetString<T>(this T toolSettings, IDictionary<string, object> setString) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal = setString.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmUpgradeSettings.SetString"/></em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T ClearSetString<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds a new key-value-pair <see cref="HelmUpgradeSettings.SetString"/></em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T AddSetString<T>(this T toolSettings, string setStringKey, object setStringValue) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal.Add(setStringKey, setStringValue);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes a key-value-pair from <see cref="HelmUpgradeSettings.SetString"/></em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T RemoveSetString<T>(this T toolSettings, string setStringKey) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal.Remove(setStringKey);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets a key-value-pair in <see cref="HelmUpgradeSettings.SetString"/></em></p>
    ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
    /// </summary>
    [Pure]
    public static T SetSetString<T>(this T toolSettings, string setStringKey, object setStringValue) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.SetStringInternal[setStringKey] = setStringValue;
        return toolSettings;
    }
    #endregion
    #region Timeout
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Timeout"/></em></p>
    ///   <p>Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).</p>
    /// </summary>
    [Pure]
    public static T SetTimeout<T>(this T toolSettings, long? timeout) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Timeout = timeout;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Timeout"/></em></p>
    ///   <p>Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).</p>
    /// </summary>
    [Pure]
    public static T ResetTimeout<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Timeout = null;
        return toolSettings;
    }
    #endregion
    #region Tls
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T SetTls<T>(this T toolSettings, bool? tls) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = tls;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ResetTls<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmUpgradeSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T EnableTls<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmUpgradeSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T DisableTls<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmUpgradeSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ToggleTls<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = !toolSettings.Tls;
        return toolSettings;
    }
    #endregion
    #region TlsCaCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCaCert<T>(this T toolSettings, string tlsCaCert) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = tlsCaCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCaCert<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCert<T>(this T toolSettings, string tlsCert) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = tlsCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCert<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsHostname
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T SetTlsHostname<T>(this T toolSettings, string tlsHostname) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = tlsHostname;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsHostname<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = null;
        return toolSettings;
    }
    #endregion
    #region TlsKey
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsKey<T>(this T toolSettings, string tlsKey) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = tlsKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsKey<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = null;
        return toolSettings;
    }
    #endregion
    #region TlsVerify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T SetTlsVerify<T>(this T toolSettings, bool? tlsVerify) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = tlsVerify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsVerify<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmUpgradeSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T EnableTlsVerify<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmUpgradeSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T DisableTlsVerify<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmUpgradeSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ToggleTlsVerify<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = !toolSettings.TlsVerify;
        return toolSettings;
    }
    #endregion
    #region Username
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Username"/></em></p>
    ///   <p>Chart repository username where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T SetUsername<T>(this T toolSettings, string username) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Username = username;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Username"/></em></p>
    ///   <p>Chart repository username where to locate the requested chart.</p>
    /// </summary>
    [Pure]
    public static T ResetUsername<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Username = null;
        return toolSettings;
    }
    #endregion
    #region Values
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Values"/> to a new list</em></p>
    ///   <p>Specify values in a YAML file or a URL(can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T SetValues<T>(this T toolSettings, params string[] values) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal = values.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Values"/> to a new list</em></p>
    ///   <p>Specify values in a YAML file or a URL(can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T SetValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal = values.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmUpgradeSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file or a URL(can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T AddValues<T>(this T toolSettings, params string[] values) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal.AddRange(values);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="HelmUpgradeSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file or a URL(can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T AddValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal.AddRange(values);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="HelmUpgradeSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file or a URL(can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T ClearValues<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ValuesInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmUpgradeSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file or a URL(can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T RemoveValues<T>(this T toolSettings, params string[] values) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(values);
        toolSettings.ValuesInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="HelmUpgradeSettings.Values"/></em></p>
    ///   <p>Specify values in a YAML file or a URL(can specify multiple) (default []).</p>
    /// </summary>
    [Pure]
    public static T RemoveValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(values);
        toolSettings.ValuesInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region Verify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Verify"/></em></p>
    ///   <p>Verify the provenance of the chart before upgrading.</p>
    /// </summary>
    [Pure]
    public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = verify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Verify"/></em></p>
    ///   <p>Verify the provenance of the chart before upgrading.</p>
    /// </summary>
    [Pure]
    public static T ResetVerify<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmUpgradeSettings.Verify"/></em></p>
    ///   <p>Verify the provenance of the chart before upgrading.</p>
    /// </summary>
    [Pure]
    public static T EnableVerify<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmUpgradeSettings.Verify"/></em></p>
    ///   <p>Verify the provenance of the chart before upgrading.</p>
    /// </summary>
    [Pure]
    public static T DisableVerify<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmUpgradeSettings.Verify"/></em></p>
    ///   <p>Verify the provenance of the chart before upgrading.</p>
    /// </summary>
    [Pure]
    public static T ToggleVerify<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Verify = !toolSettings.Verify;
        return toolSettings;
    }
    #endregion
    #region Version
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Version"/></em></p>
    ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
    /// </summary>
    [Pure]
    public static T SetVersion<T>(this T toolSettings, string version) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = version;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Version"/></em></p>
    ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
    /// </summary>
    [Pure]
    public static T ResetVersion<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Version = null;
        return toolSettings;
    }
    #endregion
    #region Wait
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Wait"/></em></p>
    ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
    /// </summary>
    [Pure]
    public static T SetWait<T>(this T toolSettings, bool? wait) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = wait;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Wait"/></em></p>
    ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
    /// </summary>
    [Pure]
    public static T ResetWait<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmUpgradeSettings.Wait"/></em></p>
    ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
    /// </summary>
    [Pure]
    public static T EnableWait<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmUpgradeSettings.Wait"/></em></p>
    ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
    /// </summary>
    [Pure]
    public static T DisableWait<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmUpgradeSettings.Wait"/></em></p>
    ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
    /// </summary>
    [Pure]
    public static T ToggleWait<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Wait = !toolSettings.Wait;
        return toolSettings;
    }
    #endregion
    #region Release
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Release"/></em></p>
    ///   <p>The name of the release to upgrade.</p>
    /// </summary>
    [Pure]
    public static T SetRelease<T>(this T toolSettings, string release) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Release = release;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Release"/></em></p>
    ///   <p>The name of the release to upgrade.</p>
    /// </summary>
    [Pure]
    public static T ResetRelease<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Release = null;
        return toolSettings;
    }
    #endregion
    #region Chart
    /// <summary>
    ///   <p><em>Sets <see cref="HelmUpgradeSettings.Chart"/></em></p>
    ///   <p>The name of the chart to upgrade.</p>
    /// </summary>
    [Pure]
    public static T SetChart<T>(this T toolSettings, string chart) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = chart;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmUpgradeSettings.Chart"/></em></p>
    ///   <p>The name of the chart to upgrade.</p>
    /// </summary>
    [Pure]
    public static T ResetChart<T>(this T toolSettings) where T : HelmUpgradeSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Chart = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmVerifySettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmVerifySettingsExtensions
{
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmVerifySettings.Help"/></em></p>
    ///   <p>Help for verify.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmVerifySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmVerifySettings.Help"/></em></p>
    ///   <p>Help for verify.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmVerifySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmVerifySettings.Help"/></em></p>
    ///   <p>Help for verify.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmVerifySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmVerifySettings.Help"/></em></p>
    ///   <p>Help for verify.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmVerifySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmVerifySettings.Help"/></em></p>
    ///   <p>Help for verify.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmVerifySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Keyring
    /// <summary>
    ///   <p><em>Sets <see cref="HelmVerifySettings.Keyring"/></em></p>
    ///   <p>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmVerifySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = keyring;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmVerifySettings.Keyring"/></em></p>
    ///   <p>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</p>
    /// </summary>
    [Pure]
    public static T ResetKeyring<T>(this T toolSettings) where T : HelmVerifySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Keyring = null;
        return toolSettings;
    }
    #endregion
    #region Path
    /// <summary>
    ///   <p><em>Sets <see cref="HelmVerifySettings.Path"/></em></p>
    ///   <p>The path to the chart to verify.</p>
    /// </summary>
    [Pure]
    public static T SetPath<T>(this T toolSettings, string path) where T : HelmVerifySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Path = path;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmVerifySettings.Path"/></em></p>
    ///   <p>The path to the chart to verify.</p>
    /// </summary>
    [Pure]
    public static T ResetPath<T>(this T toolSettings) where T : HelmVerifySettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Path = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmVersionSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmVersionSettingsExtensions
{
    #region Client
    /// <summary>
    ///   <p><em>Sets <see cref="HelmVersionSettings.Client"/></em></p>
    ///   <p>Client version only.</p>
    /// </summary>
    [Pure]
    public static T SetClient<T>(this T toolSettings, bool? client) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Client = client;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmVersionSettings.Client"/></em></p>
    ///   <p>Client version only.</p>
    /// </summary>
    [Pure]
    public static T ResetClient<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Client = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmVersionSettings.Client"/></em></p>
    ///   <p>Client version only.</p>
    /// </summary>
    [Pure]
    public static T EnableClient<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Client = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmVersionSettings.Client"/></em></p>
    ///   <p>Client version only.</p>
    /// </summary>
    [Pure]
    public static T DisableClient<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Client = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmVersionSettings.Client"/></em></p>
    ///   <p>Client version only.</p>
    /// </summary>
    [Pure]
    public static T ToggleClient<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Client = !toolSettings.Client;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmVersionSettings.Help"/></em></p>
    ///   <p>Help for version.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmVersionSettings.Help"/></em></p>
    ///   <p>Help for version.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmVersionSettings.Help"/></em></p>
    ///   <p>Help for version.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmVersionSettings.Help"/></em></p>
    ///   <p>Help for version.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmVersionSettings.Help"/></em></p>
    ///   <p>Help for version.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Server
    /// <summary>
    ///   <p><em>Sets <see cref="HelmVersionSettings.Server"/></em></p>
    ///   <p>Server version only.</p>
    /// </summary>
    [Pure]
    public static T SetServer<T>(this T toolSettings, bool? server) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Server = server;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmVersionSettings.Server"/></em></p>
    ///   <p>Server version only.</p>
    /// </summary>
    [Pure]
    public static T ResetServer<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Server = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmVersionSettings.Server"/></em></p>
    ///   <p>Server version only.</p>
    /// </summary>
    [Pure]
    public static T EnableServer<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Server = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmVersionSettings.Server"/></em></p>
    ///   <p>Server version only.</p>
    /// </summary>
    [Pure]
    public static T DisableServer<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Server = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmVersionSettings.Server"/></em></p>
    ///   <p>Server version only.</p>
    /// </summary>
    [Pure]
    public static T ToggleServer<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Server = !toolSettings.Server;
        return toolSettings;
    }
    #endregion
    #region Short
    /// <summary>
    ///   <p><em>Sets <see cref="HelmVersionSettings.Short"/></em></p>
    ///   <p>Print the version number.</p>
    /// </summary>
    [Pure]
    public static T SetShort<T>(this T toolSettings, bool? @short) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Short = @short;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmVersionSettings.Short"/></em></p>
    ///   <p>Print the version number.</p>
    /// </summary>
    [Pure]
    public static T ResetShort<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Short = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmVersionSettings.Short"/></em></p>
    ///   <p>Print the version number.</p>
    /// </summary>
    [Pure]
    public static T EnableShort<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Short = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmVersionSettings.Short"/></em></p>
    ///   <p>Print the version number.</p>
    /// </summary>
    [Pure]
    public static T DisableShort<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Short = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmVersionSettings.Short"/></em></p>
    ///   <p>Print the version number.</p>
    /// </summary>
    [Pure]
    public static T ToggleShort<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Short = !toolSettings.Short;
        return toolSettings;
    }
    #endregion
    #region Template
    /// <summary>
    ///   <p><em>Sets <see cref="HelmVersionSettings.Template"/></em></p>
    ///   <p>Template for version string format.</p>
    /// </summary>
    [Pure]
    public static T SetTemplate<T>(this T toolSettings, string template) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Template = template;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmVersionSettings.Template"/></em></p>
    ///   <p>Template for version string format.</p>
    /// </summary>
    [Pure]
    public static T ResetTemplate<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Template = null;
        return toolSettings;
    }
    #endregion
    #region Tls
    /// <summary>
    ///   <p><em>Sets <see cref="HelmVersionSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T SetTls<T>(this T toolSettings, bool? tls) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = tls;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmVersionSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ResetTls<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmVersionSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T EnableTls<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmVersionSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T DisableTls<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmVersionSettings.Tls"/></em></p>
    ///   <p>Enable TLS for request.</p>
    /// </summary>
    [Pure]
    public static T ToggleTls<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Tls = !toolSettings.Tls;
        return toolSettings;
    }
    #endregion
    #region TlsCaCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmVersionSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCaCert<T>(this T toolSettings, string tlsCaCert) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = tlsCaCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmVersionSettings.TlsCaCert"/></em></p>
    ///   <p>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCaCert<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCaCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsCert
    /// <summary>
    ///   <p><em>Sets <see cref="HelmVersionSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsCert<T>(this T toolSettings, string tlsCert) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = tlsCert;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmVersionSettings.TlsCert"/></em></p>
    ///   <p>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsCert<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsCert = null;
        return toolSettings;
    }
    #endregion
    #region TlsHostname
    /// <summary>
    ///   <p><em>Sets <see cref="HelmVersionSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T SetTlsHostname<T>(this T toolSettings, string tlsHostname) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = tlsHostname;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmVersionSettings.TlsHostname"/></em></p>
    ///   <p>The server name used to verify the hostname on the returned certificates from the server.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsHostname<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsHostname = null;
        return toolSettings;
    }
    #endregion
    #region TlsKey
    /// <summary>
    ///   <p><em>Sets <see cref="HelmVersionSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T SetTlsKey<T>(this T toolSettings, string tlsKey) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = tlsKey;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmVersionSettings.TlsKey"/></em></p>
    ///   <p>Path to TLS key file (default "$HELM_HOME/key.pem").</p>
    /// </summary>
    [Pure]
    public static T ResetTlsKey<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsKey = null;
        return toolSettings;
    }
    #endregion
    #region TlsVerify
    /// <summary>
    ///   <p><em>Sets <see cref="HelmVersionSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T SetTlsVerify<T>(this T toolSettings, bool? tlsVerify) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = tlsVerify;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmVersionSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ResetTlsVerify<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmVersionSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T EnableTlsVerify<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmVersionSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T DisableTlsVerify<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmVersionSettings.TlsVerify"/></em></p>
    ///   <p>Enable TLS for request and verify remote.</p>
    /// </summary>
    [Pure]
    public static T ToggleTlsVerify<T>(this T toolSettings) where T : HelmVersionSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TlsVerify = !toolSettings.TlsVerify;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmCommonSettingsExtensions
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmCommonSettingsExtensions
{
    #region Debug
    /// <summary>
    ///   <p><em>Sets <see cref="HelmCommonSettings.Debug"/></em></p>
    ///   <p>Enable verbose output.</p>
    /// </summary>
    [Pure]
    public static T SetDebug<T>(this T toolSettings, bool? debug) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Debug = debug;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmCommonSettings.Debug"/></em></p>
    ///   <p>Enable verbose output.</p>
    /// </summary>
    [Pure]
    public static T ResetDebug<T>(this T toolSettings) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Debug = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmCommonSettings.Debug"/></em></p>
    ///   <p>Enable verbose output.</p>
    /// </summary>
    [Pure]
    public static T EnableDebug<T>(this T toolSettings) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Debug = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmCommonSettings.Debug"/></em></p>
    ///   <p>Enable verbose output.</p>
    /// </summary>
    [Pure]
    public static T DisableDebug<T>(this T toolSettings) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Debug = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmCommonSettings.Debug"/></em></p>
    ///   <p>Enable verbose output.</p>
    /// </summary>
    [Pure]
    public static T ToggleDebug<T>(this T toolSettings) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Debug = !toolSettings.Debug;
        return toolSettings;
    }
    #endregion
    #region Help
    /// <summary>
    ///   <p><em>Sets <see cref="HelmCommonSettings.Help"/></em></p>
    ///   <p>Help for helm.</p>
    /// </summary>
    [Pure]
    public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = help;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmCommonSettings.Help"/></em></p>
    ///   <p>Help for helm.</p>
    /// </summary>
    [Pure]
    public static T ResetHelp<T>(this T toolSettings) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = null;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Enables <see cref="HelmCommonSettings.Help"/></em></p>
    ///   <p>Help for helm.</p>
    /// </summary>
    [Pure]
    public static T EnableHelp<T>(this T toolSettings) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = true;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Disables <see cref="HelmCommonSettings.Help"/></em></p>
    ///   <p>Help for helm.</p>
    /// </summary>
    [Pure]
    public static T DisableHelp<T>(this T toolSettings) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = false;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Toggles <see cref="HelmCommonSettings.Help"/></em></p>
    ///   <p>Help for helm.</p>
    /// </summary>
    [Pure]
    public static T ToggleHelp<T>(this T toolSettings) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Help = !toolSettings.Help;
        return toolSettings;
    }
    #endregion
    #region Home
    /// <summary>
    ///   <p><em>Sets <see cref="HelmCommonSettings.Home"/></em></p>
    ///   <p>Location of your Helm config. Overrides $HELM_HOME (default "~/.helm").</p>
    /// </summary>
    [Pure]
    public static T SetHome<T>(this T toolSettings, string home) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Home = home;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmCommonSettings.Home"/></em></p>
    ///   <p>Location of your Helm config. Overrides $HELM_HOME (default "~/.helm").</p>
    /// </summary>
    [Pure]
    public static T ResetHome<T>(this T toolSettings) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Home = null;
        return toolSettings;
    }
    #endregion
    #region Host
    /// <summary>
    ///   <p><em>Sets <see cref="HelmCommonSettings.Host"/></em></p>
    ///   <p>Address of Tiller. Overrides $HELM_HOST.</p>
    /// </summary>
    [Pure]
    public static T SetHost<T>(this T toolSettings, string host) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Host = host;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmCommonSettings.Host"/></em></p>
    ///   <p>Address of Tiller. Overrides $HELM_HOST.</p>
    /// </summary>
    [Pure]
    public static T ResetHost<T>(this T toolSettings) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Host = null;
        return toolSettings;
    }
    #endregion
    #region KubeContext
    /// <summary>
    ///   <p><em>Sets <see cref="HelmCommonSettings.KubeContext"/></em></p>
    ///   <p>Name of the kubeconfig context to use.</p>
    /// </summary>
    [Pure]
    public static T SetKubeContext<T>(this T toolSettings, string kubeContext) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KubeContext = kubeContext;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmCommonSettings.KubeContext"/></em></p>
    ///   <p>Name of the kubeconfig context to use.</p>
    /// </summary>
    [Pure]
    public static T ResetKubeContext<T>(this T toolSettings) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.KubeContext = null;
        return toolSettings;
    }
    #endregion
    #region Kubeconfig
    /// <summary>
    ///   <p><em>Sets <see cref="HelmCommonSettings.Kubeconfig"/></em></p>
    ///   <p>Absolute path to the kubeconfig file to use.</p>
    /// </summary>
    [Pure]
    public static T SetKubeconfig<T>(this T toolSettings, string kubeconfig) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Kubeconfig = kubeconfig;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmCommonSettings.Kubeconfig"/></em></p>
    ///   <p>Absolute path to the kubeconfig file to use.</p>
    /// </summary>
    [Pure]
    public static T ResetKubeconfig<T>(this T toolSettings) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Kubeconfig = null;
        return toolSettings;
    }
    #endregion
    #region TillerConnectionTimeout
    /// <summary>
    ///   <p><em>Sets <see cref="HelmCommonSettings.TillerConnectionTimeout"/></em></p>
    ///   <p>The duration (in seconds) Helm will wait to establish a connection to tiller (default 300).</p>
    /// </summary>
    [Pure]
    public static T SetTillerConnectionTimeout<T>(this T toolSettings, long? tillerConnectionTimeout) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerConnectionTimeout = tillerConnectionTimeout;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmCommonSettings.TillerConnectionTimeout"/></em></p>
    ///   <p>The duration (in seconds) Helm will wait to establish a connection to tiller (default 300).</p>
    /// </summary>
    [Pure]
    public static T ResetTillerConnectionTimeout<T>(this T toolSettings) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerConnectionTimeout = null;
        return toolSettings;
    }
    #endregion
    #region TillerNamespace
    /// <summary>
    ///   <p><em>Sets <see cref="HelmCommonSettings.TillerNamespace"/></em></p>
    ///   <p>Namespace of Tiller (default "kube-system").</p>
    /// </summary>
    [Pure]
    public static T SetTillerNamespace<T>(this T toolSettings, string tillerNamespace) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerNamespace = tillerNamespace;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="HelmCommonSettings.TillerNamespace"/></em></p>
    ///   <p>Namespace of Tiller (default "kube-system").</p>
    /// </summary>
    [Pure]
    public static T ResetTillerNamespace<T>(this T toolSettings) where T : HelmCommonSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TillerNamespace = null;
        return toolSettings;
    }
    #endregion
}
#endregion
#region HelmOutputFormat
/// <summary>
///   Used within <see cref="HelmTasks"/>.
/// </summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmOutputFormat>))]
public partial class HelmOutputFormat : Enumeration
{
    public static HelmOutputFormat json = (HelmOutputFormat) "json";
    public static HelmOutputFormat yaml = (HelmOutputFormat) "yaml";
    public static implicit operator HelmOutputFormat(string value)
    {
        return new HelmOutputFormat { Value = value };
    }
}
#endregion
