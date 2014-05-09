﻿#region Copyright 2014 Exceptionless

// This program is free software: you can redistribute it and/or modify it 
// under the terms of the GNU Affero General Public License as published 
// by the Free Software Foundation, either version 3 of the License, or 
// (at your option) any later version.
// 
//     http://www.gnu.org/licenses/agpl-3.0.html

#endregion

using System;
using Exceptionless.Core.Caching;
using Exceptionless.Core.Jobs;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Exceptionless.Core.Repositories {
    public class JobLockRepository : MongoRepository<JobLockInfo>, IJobLockInfoRepository {
        public JobLockRepository(MongoDatabase database, ICacheClient cacheClient = null) : base(database, cacheClient) {
            _getIdValue = s => s;
        }

        #region Collection Setup

        public const string CollectionName = "joblock";

        protected override string GetCollectionName() {
            return CollectionName;
        }

        protected override void ConfigureClassMap(BsonClassMap<JobLockInfo> cm) {
            base.ConfigureClassMap(cm);
            cm.SetIdMember(cm.GetMemberMap(c => c.Id));
        }

        #endregion
    }
}