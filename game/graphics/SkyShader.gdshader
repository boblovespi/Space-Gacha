shader_type sky;

const vec3 sunDir = vec3(1.0, 0.0, 0.0);

const vec3 RAND_SEED = vec3(999.9, 997.9, 979.9);

// compute a psuedorandom float given direction
float rand(vec3 pos)
{
	return fract(sin(dot(pos, RAND_SEED)) * 123.0);
}

vec3 rand3(vec3 pos)
{
	return vec3(rand(pos + vec3(1.0)), rand(pos + vec3(2.0)), rand(pos + vec3(3.0)));
}

const float scale = 50.0;
const vec3 corners[8] = { 
	vec3(0.0), 
	vec3(1.0, 0.0, 0.0), 
	vec3(0.0, 1.0, 0.0), 
	vec3(0.0, 0.0, 1.0),
	vec3(1.0, 1.0, 0.0),
	vec3(1.0, 0.0, 1.0),
	vec3(0.0, 1.0, 1.0),
	vec3(1.0)};
	
vec3 rand3GP(vec3 pos)
{
	vec3 realGridPos = floor(scale * pos);
	return rand3(realGridPos);
}

float randSparse(vec3 pos)
{
	vec3 realGridPos = floor(scale * pos);
	for (int i = 0; i < 8; i++)
	{
		vec3 gridPos = realGridPos + corners[i];
		if (rand(gridPos) > 0.9)
		{
			vec3 offset = rand3(gridPos);
			float size = rand(gridPos + vec3(-5.0)) / scale / 4.5;
			vec3 dotPos = gridPos / scale + offset / scale / 2.0;
			float len = size - length(dotPos - pos);
			if (len < 0.0)
				return 0.0;
			float val = len / size + 0.4;
			return clamp(val * val * val * val * val * val * val, 0.0, 1.0);
		}
	}
	return 0.0;
}

void sky() {
	// Place sky code here.
	COLOR = vec3(0.002, 0.0, 0.006);

	if (!AT_CUBEMAP_PASS) // draw stars
	{
		COLOR += randSparse(EYEDIR) * (rand3GP(EYEDIR) + vec3(0.6)); // * (sin(TIME + dot(rand3GP(EYEDIR), vec3(10.0, 11.0, 15.0))) + 1.2);
	}

	float d = dot(EYEDIR, sunDir);
	if (d > 0.9)
		COLOR = vec3(3.0, 1.9, 1.2) * pow(d, 7.0);
	if (d > 0.8)
		COLOR += vec3(1.0, 0.6, 0.2) * pow(5.0 * (d - 0.8), 4.0);
}
