// Copyright (c) Matt Lavallee
// Licensed under the MIT License.
// See License.txt in the project root for more license information.

using CommandLine;

namespace SafeDeposit.Options
{
    [Verb("push", HelpText = "Push updates from a User Secrets file to an Azure Key Vault.", Hidden = false)]
    public class PushOptions : BaseOptions
    {
    }
}
