﻿// ======================================================================
// DMOLibrary
// Copyright (C) 2015 Ilya Egorov (goldrenard@gmail.com)

// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with this program. If not, see <http://www.gnu.org/licenses/>.
// ======================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DMOLibrary.Database.Entity {

    public class Guild : BaseEntity {

        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Guild() {
            Tamers = new List<Tamer>();
        }

        public int Identifier {
            get;
            set;
        }

        [Required]
        [ForeignKey("Server")]
        public long ServerId {
            get;
            set;
        }

        [InverseProperty("Guilds")]
        public virtual Server Server {
            get;
            set;
        }

        [Required]
        public string Name {
            get;
            set;
        }

        public long Rep {
            get;
            set;
        }

        public long Rank {
            get;
            set;
        }

        public DateTime? UpdateTime {
            get;
            set;
        }

        public bool IsDetailed {
            get;
            set;
        }

        [NotMapped]
        public Tamer Master {
            get {
                return Tamers.First(t => t.IsMaster);
            }
        }

        public virtual ICollection<Tamer> Tamers {
            get;
            set;
        }

        public override string ToString() {
            return string.Format("Guild [Identifier={0}, Name={1}]", Identifier, Name);
        }
    }
}