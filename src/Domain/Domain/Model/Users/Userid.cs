using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Model.Users
{
    /// <summary>
    /// ユーザーID。ValueObject
    /// </summary>
    public class UserId : IEquatable<UserId>
    {
        public UserId(long id)
        {
            Value = id;
        }

        public long Value { get; }

        public bool Equals(UserId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserId)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
