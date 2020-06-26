using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectEvent : UnityEvent<Object> { }
public class MonobehaviourEvent : UnityEvent<MonoBehaviour> { }

public class Vector3Event : UnityEvent<Vector3> { }

public class IntEvent : UnityEvent<int> { }

public class ScenarioEvent : UnityEvent<Scenario> { }

public class EmptyEvent : UnityEvent { }

public class BoolEvent : UnityEvent<bool> { }

public class DeathEvent : UnityEvent<Vector3, Color, bool> { }
