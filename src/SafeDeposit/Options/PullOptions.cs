// Copyright (c) Matt Lavallee
// Licensed under the MIT License.
// See License.txt in the project root for more license information.

using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace SafeDeposit.Options
{
    [Verb("pull", HelpText = "Pull secrets from an Azure Key Vault to a User Secrets file.")]
    public class PullOptions : BaseOptions
    {
    }
}
