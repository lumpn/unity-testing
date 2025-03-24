//----------------------------------------
// MIT License
// Copyright(c) 2025 Jonas Boetel
//----------------------------------------
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using Array = System.Array;

namespace Lumpn.Testing
{
    public sealed class NUnitAssertionProvider : IAssertionProvider
    {
        private struct Context
        {
            private Component component;
            private ScriptableObject scriptableObject;
            private string cachedPath;

            public string path
            {
                get
                {
                    if (string.IsNullOrEmpty(cachedPath))
                    {
                        if (component)
                        {
                            var type = component.GetType();
                            var assetPath = AssetDatabase.GetAssetPath(component);
                            var scriptPath = GetPath(component.transform);
                            cachedPath = $"{assetPath}/{type}/{scriptPath}";
                        }
                        else
                        {
                            var type = scriptableObject.GetType();
                            var assetPath = AssetDatabase.GetAssetPath(scriptableObject);
                            cachedPath = $"{assetPath}/{type}";
                        }
                    }
                    return cachedPath;
                }
            }

            public static Context Create(Component component)
            {
                return new Context { component = component };
            }

            public static Context Create(ScriptableObject scriptableObject)
            {
                return new Context { scriptableObject = scriptableObject };
            }

            private static string GetPath(Transform tr)
            {
                var parent = tr.parent;
                return (!parent) ? tr.name : $"{GetPath(parent)}/{tr.name}";
            }
        }

        private Context context;

        public void SetContext(Component context)
        {
            this.context = Context.Create(context);
        }

        public void SetContext(ScriptableObject context)
        {
            this.context = Context.Create(context);
        }

        public void IsFieldAssigned(Object field, string fieldName)
        {
            if (!field)
            {
                Assert.Fail("Unassigned field '{0}' in '{1}'", fieldName, context.path);
            }
        }

        public void IsFieldNotEmpty(string field, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(field))
            {
                Assert.Fail("Empty field '{0}' in '{1}'", fieldName, context.path);
            }
        }

        public void IsFieldNotEmpty(Array field, string fieldName)
        {
            if (field == null || field.Length < 1)
            {
                Assert.Fail("Empty field '{0}' in '{1}'", fieldName, context.path);
            }
        }

        public void IsFieldNotNegative(int field, string fieldName)
        {
            if (field < 0)
            {
                Assert.Fail("Negative field '{0}' in '{1}'", fieldName, context.path);
            }
        }

        public void IsFieldNotNull(Array field, string fieldName)
        {
            if (field == null)
            {
                Assert.Fail("Null field '{0}' in '{1}'", fieldName, context.path);
            }
        }

        public void IsFieldOne(Vector3 field, string fieldName)
        {
            if (field != Vector3.one)
            {
                Assert.Fail("Non-one field '{0}' in '{1}'", fieldName, context.path);
            }
        }

        public void IsFieldZero(Vector3 field, string fieldName)
        {
            if (field != Vector3.zero)
            {
                Assert.Fail("Non-zero field '{0}' in '{1}'", fieldName, context.path);
            }
        }

        public void IsFieldZero(Quaternion field, string fieldName)
        {
            if (field != Quaternion.identity)
            {
                Assert.Fail("Non-zero field '{0}' in '{1}'", fieldName, context.path);
            }
        }

        public void IsTrue(bool condition, string format, params object[] args)
        {
            if (!condition)
            {
                var formatWithContext = $"{format} in '{context.path}'";
                Assert.Fail(formatWithContext, args);
            }
        }
    }
}
