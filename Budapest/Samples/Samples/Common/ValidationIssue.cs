﻿using System.Collections.Generic;

namespace KadGen.Functional.Common
{
    public class ValidationIssue
    {
        public ValidationIssue(ValidationIssueId issueId, params string[] fieldNames)
        {
            ValidationIssueId = issueId;
            FieldNames = fieldNames;
        }

        public ValidationIssueId ValidationIssueId { get; }
        public IEnumerable<string> FieldNames { get; } //normally contains one
    }

    public enum ValidationIssueId
    {
        Unknown = 0,
        RequiredValueMissing,
        StringTooShort
    }
}
