using System;

[Serializable]
public class Directions{
	public Route[] routes;
}

[Serializable]
public class Route{
	public Leg[] legs;
}

[Serializable]
public class Leg{
	public Step[] steps;
}

[Serializable]
public class Step{
	public Distance distance;
	public Duration duration;
	public Location start_location;
	public Location end_location;
}

[Serializable]
public class Duration{
	public int value;
}

[Serializable]
public class Distance{
	public int value;
}