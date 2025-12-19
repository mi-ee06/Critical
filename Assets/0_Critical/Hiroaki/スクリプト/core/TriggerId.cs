using System;

namespace core
{
    public struct TriggerId : IEquatable<TriggerId>
    {
        public readonly int Hash;
        public readonly string Name;
        public TriggerId(string name)
        {
            Name = name;
            Hash = HashUtil.Hash(name);
        }
        public bool Equals(TriggerId other)
        {
            return Hash == other.Hash;
        }
        public override bool Equals(object obj)
        {
            return obj is TriggerId other && Equals(other);
        }
        public override int GetHashCode()
        {
            return Hash;
        }
    }
}