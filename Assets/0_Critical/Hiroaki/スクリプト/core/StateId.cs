using System;

namespace core
{
    public struct StateId :IEquatable<StateId>
    {
        public readonly int Hash;
        public readonly string Name;
        public StateId(string name)
        {
            Name = name;
            Hash = HashUtil.Hash(name);
        }
        public bool Equals(StateId other)
        {
            return Hash == other.Hash;
        }
        public override bool Equals(object obj)
        {
            return obj is StateId other && Equals(other);
        }
        public override int GetHashCode()
        {
            return Hash;
        }
    }
}