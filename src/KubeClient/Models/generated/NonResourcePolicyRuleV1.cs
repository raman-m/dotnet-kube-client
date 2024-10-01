using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace KubeClient.Models
{
    /// <summary>
    ///     NonResourcePolicyRule is a predicate that matches non-resource requests according to their verb and the target non-resource URL. A NonResourcePolicyRule matches a request if and only if both (a) at least one member of verbs matches the request and (b) at least one member of nonResourceURLs matches the request.
    /// </summary>
    public partial class NonResourcePolicyRuleV1
    {
        /// <summary>
        ///     `nonResourceURLs` is a set of url prefixes that a user should have access to and may not be empty. For example:
        ///       - "/healthz" is legal
        ///       - "/hea*" is illegal
        ///       - "/hea" is legal but matches nothing
        ///       - "/hea/*" also matches nothing
        ///       - "/healthz/*" matches all per-component health checks.
        ///     "*" matches all non-resource urls. if it is present, it must be the only entry. Required.
        /// </summary>
        [YamlMember(Alias = "nonResourceURLs")]
        [JsonProperty("nonResourceURLs", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public List<string> NonResourceURLs { get; } = new List<string>();

        /// <summary>
        ///     `verbs` is a list of matching verbs and may not be empty. "*" matches all verbs. If it is present, it must be the only entry. Required.
        /// </summary>
        [YamlMember(Alias = "verbs")]
        [JsonProperty("verbs", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public List<string> Verbs { get; } = new List<string>();
    }
}
