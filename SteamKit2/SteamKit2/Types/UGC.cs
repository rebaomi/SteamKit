﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SteamKit2
{
    /// <summary>
    /// The base class used for wrapping common ulong types, to introduce type safety and distinguish between common types.
    /// </summary>
    [DebuggerDisplay( "{Value}" )]
    public abstract class UInt64Handle : IEquatable<UInt64Handle>
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        protected ulong Value { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="UInt64Handle"/> class.
        /// </summary>
        public UInt64Handle()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UInt64Handle"/> class.
        /// </summary>
        /// <param name="value">The value to initialize this handle to.</param>
        protected UInt64Handle( ulong value )
        {
            this.Value = value;
        }


        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals( object obj )
        {
            if ( obj == null )
                return false;

            UInt64Handle handle = obj as UInt64Handle;

            if ( ( object )handle == null )
                return false;

            return handle.Value == Value;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Value.ToString();
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the other parameter; otherwise, false.
        /// </returns>
        public bool Equals( UInt64Handle other )
        {
            if ( ( object )other == null )
                return false;

            return Value == other.Value;
        }

    }

// warning CS0660: 'SteamKit2.UGCHandle' defines operator == or operator != but does not override Object.Equals(object o)
// this is disabled because our base UInt64Handle class handles Object.Equals for us
#pragma warning disable 0660
#pragma warning disable 0661

    /// <summary>
    /// Represents a single unique handle to a piece of User Generated Content.
    /// </summary>
    public sealed class UGCHandle : UInt64Handle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UGCHandle"/> class.
        /// </summary>
        /// <param name="ugcId">The ugc handle id.</param>
        public UGCHandle( ulong ugcId = ulong.MaxValue )
            : base( ugcId )
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="SteamKit2.UGCHandle"/> to <see cref="System.UInt64"/>.
        /// </summary>
        /// <param name="ugc">The UGC handle.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator ulong( UGCHandle ugc )
        {
            return ugc.Value;
        }
        /// <summary>
        /// Performs an implicit conversion from <see cref="System.UInt64"/> to <see cref="SteamKit2.UGCHandle"/>.
        /// </summary>
        /// <param name="ugcId">The ugc id.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator UGCHandle( ulong ugcId )
        {
            return new UGCHandle( ugcId );
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">The first handle.</param>
        /// <param name="b">The second handle.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==( UGCHandle a, UGCHandle b )
        {
            if ( object.ReferenceEquals( a, b ) )
                return true;

            if ( ( ( object )a == null ) || ( ( object )b == null ) )
                return false;

            return a.Value == b.Value;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">The first handle.</param>
        /// <param name="b">The second handle.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=( UGCHandle a, UGCHandle b )
        {
            return !( a == b );
        }
    }

    /// <summary>
    /// Represents a handle to a published file on the Steam workshop.
    /// </summary>
    public sealed class PublishedFileID : UInt64Handle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PublishedFileID"/> class.
        /// </summary>
        /// <param name="fileId">The file id.</param>
        public PublishedFileID( ulong fileId = ulong.MaxValue )
            : base( fileId )
        {
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="SteamKit2.PublishedFileID"/> to <see cref="System.UInt64"/>.
        /// </summary>
        /// <param name="file">The published file.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator ulong( PublishedFileID file )
        {
            return file.Value;
        }
        /// <summary>
        /// Performs an implicit conversion from <see cref="System.UInt64"/> to <see cref="SteamKit2.PublishedFileID"/>.
        /// </summary>
        /// <param name="fileId">The file id.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator PublishedFileID( ulong fileId )
        {
            return new PublishedFileID( fileId );
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">The first published file.</param>
        /// <param name="b">The second published file.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==( PublishedFileID a, PublishedFileID b )
        {
            if ( object.ReferenceEquals( a, b ) )
                return true;

            if ( ( ( object )a == null ) || ( ( object )b == null ) )
                return false;

            return a.Value == b.Value;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">The first published file.</param>
        /// <param name="b">The second published file.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=( PublishedFileID a, PublishedFileID b )
        {
            return !( a == b );
        }
    }

#pragma warning restore 0660
#pragma warning disable 0661

}