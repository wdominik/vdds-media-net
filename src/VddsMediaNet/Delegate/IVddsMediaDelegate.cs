using System;
using System.Collections.Generic;

namespace VddsMediaNet.Delegate
{
    public interface IVddsMediaDelegate
    {
        void ImportPatient(IPatient patient);

        void ShowPatient(string id);

        IEnumerable<MultimediaObject> GetMultimediaObjectsForPatient(string id, DateTime? fromDate = null);

        string GetPathForMultimediaObject(string id);
    }
}