﻿using System;
using System.Collections.Generic;
using System.Linq;
using Google.Protobuf.WellKnownTypes;

namespace RpcApi.Repositories
{
    public class ConferenceMemoryRepo : IConferenceRepo
    {
        private readonly List<Conference> conferences = new List<Conference>();

        public ConferenceMemoryRepo()
        {
            conferences.Add(new Conference { Id = 1, Name = "VS Live", Location = "Orlando", Start = Timestamp.FromDateTime(new DateTime(2019, 11, 25).ToUniversalTime()), AttendeeTotal = 719 });
            conferences.Add(new Conference { Id = 2, Name = "Pluralsight Live!", Location = "Salt Lake City", Start = Timestamp.FromDateTime(new DateTime(2019, 11, 22).ToUniversalTime()), AttendeeTotal = 3210 });
        }
        public IEnumerable<Conference> GetAll()
        {
            return conferences;
        }

        public Conference Add(Conference model)
        {
            model.Id = conferences.Max(c => c.Id) + 1;
            conferences.Add(model);
            return model;
        }

        public Conference GetOne(int id)
        {
            return conferences.Single(c => c.Id == id);
        }
    }
}
