﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VIN.Domain.Model
{
    public abstract class EntityRoot : IEquatable<EntityRoot>
    {
        public Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as EntityRoot;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(EntityRoot a, EntityRoot b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntityRoot a, EntityRoot b) => !(a == b);

        public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();

        public override string ToString() => GetType().Name + " [Id=" + Id + "]";

        public bool Equals(EntityRoot other) => this.Equals(other as EntityRoot);
    }
}
