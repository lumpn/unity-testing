//----------------------------------------
// MIT License
// Copyright(c) 2025 Jonas Boetel
//----------------------------------------
using UnityEngine;
using Array = System.Array;

namespace Lumpn.Testing
{
    public interface IAssertionProvider
    {
        void SetContext(Component context);
        void SetContext(ScriptableObject context);

        void IsFieldAssigned(Object field, string fieldName);
        void IsFieldNotEmpty(string field, string fieldName);
        void IsFieldNotEmpty(Array field, string fieldName);
        void IsFieldNotNegative(int field, string fieldName);
        void IsFieldNotNull(Array field, string fieldName);
        void IsFieldOne(Vector3 field, string fieldName);
        void IsFieldZero(Vector3 field, string fieldName);
        void IsFieldZero(Quaternion field, string fieldName);
        void IsTrue(bool condition, string format, params object[] args);
    }
}
