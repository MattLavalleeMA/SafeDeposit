// Copyright (c) Matt Lavallee
// Licensed under the MIT License.
// See License.txt in the project root for more license information.

using System.Collections.Generic;
using CommandLine;

namespace SafeDeposit.Options
{
    public class BaseOptions
    {
        [Option('a', "append", HelpText = "Add new keys, but do not update existing or remove missing keys.", Required = false, Hidden = false, Default = true)]
        public bool Append { get; set; }

        [Option('f', "file", HelpText = "The User Secrets file that is the source of a push or target of a pull operation.", Required = false, Hidden = false)]
        public string File { get; set; }

        [Option('n', "no-update", HelpText = "List the proposed updates without committing them.", Required = false, Hidden = false, Default = false)]
        public bool NoUpdate { get; set; }

        [Option('p', "project", HelpText = "Specify a project file to use its UserSecretsId file reference.", Required = false, Hidden = false)]
        public string Project { get; set; }

        [Option('e', "prefix", HelpText = "Use a key prefix in the Azure Key Vault when synchronizing.", Required = false, Hidden = false)]
        public string Prefix { get; set; }

        [Option('r', "rebase", HelpText = "All missing keys are deleted from the target.", Required = false, Hidden = false, Default = false)]
        public bool Rebase { get; set; }

        [Option('k', "keyvault", HelpText = "Specify an Azure Key Vault.", Required = true, Hidden = false)]
        public string Vault { get; set; }

        [Value(0, Default = null, HelpText = "Glob search pattern(s) for keys to include.", Hidden = false, Required = false)]
        public IEnumerable<string> Patterns { get; set; }
    }
}