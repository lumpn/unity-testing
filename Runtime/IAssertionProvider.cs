//----------------------------------------
// MIT License
// Copyright(c) 2025 Jonas Boetel
//----------------------------------------
using UnityEngine;
using Array = System.Array;
using Enum = System.Enum;

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
        void IsFieldNotNegative(long field, string fieldName);
        void IsFieldNotNull(Array field, string fieldName);
        void IsFieldEmpty(string field, string fieldName);
        void IsFieldOne(Vector3 field, string fieldName);
        void IsFieldZero(int field, string fieldName);
        void IsFieldZero(Vector3 field, string fieldName);
        void IsFieldZero(Quaternion field, string fieldName);
        void IsFieldEqual(string expected, int expectedStart, string field, string fieldName);
        void IsFieldEqual(bool expected, bool field, string fieldName);
        void IsFieldEqual(Enum expected, Enum field, string fieldName);
        void IsFieldNotEqual(Enum expected, Enum field, string fieldName);
        void IsFieldGreater(int threshold, int field, string fieldName);
        void IsFieldGreater(long threshold, long field, string fieldName);
        void IsFieldGreater(float threshold, float field, string fieldName);
        void IsTrue(bool condition, string format, params object[] args);
    }
}
