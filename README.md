# Tecto
This will eventually be a tectonic plate simulator made in c# and unity.

The aim of this software is for worldbuilders to make realistic earth-like planets without the unnatural noisemap look.
Making the software in unity will provide a framework to interact with and visualise the model as it is being built.

#The Mantle
This program uses a vector field with many forces acting at a tangent to the surface of the planet to move the plates. This is reminiscent of the assumption that plates are moved by convection currents within the mantle. This is no longer the accepted thought in geology, but as this is an abstraction anyway, we will use it regardless. We also have the capability to incorporate other variables into the force vector field, so we may be able to surpass the simple assumptions.

The mantle consists of a number of points that are generated about the surface of a sphere approximately evenly. This uses the "Fibonacci sphere" technique. Each of these points will have a force vector associated with it that acts at a tangent to the sphere at a bearing from north. With the force vectors found, they can be applied to each plate. This is easiest using spherical coordinates, though they will need to be converted to cartesian coordinates eventually for unity to use them.
