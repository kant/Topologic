// This file is part of Topologic software library.
// Copyright(C) 2019, Cardiff University and University College London
//
// This program is free software : you can redistribute it and/or modify it
// under the terms of the GNU Affero General Public License version 3 (AGPL v3)
// as published by the Free Software Foundation.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
//
// Please consult the file LICENSE.txt included in Topologic distribution
// for complete text of the license and disclaimer of any warranty.
// Alternatively, please see https://www.gnu.org/licenses/agpl-3.0.en.html.

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace TopologicGH
{
    public class GraphShortestPath : GH_Component
    {

        public GraphShortestPath()
          : base("Graph.ShortestPath", "Graph.ShortestPath", "Returns the path with the fewest number of Edges between the two input Vertices.", "Topologic", "Graph")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Graph", "Graph", "Graph", GH_ParamAccess.item);
            pManager.AddGenericParameter("Start Vertex", "Start Vertex", "Start Vertex", GH_ParamAccess.item);
            pManager.AddGenericParameter("End Vertex", "End Vertex", "End Vertex", GH_ParamAccess.item);
            pManager.AddTextParameter("Vertex Key", "Vertex Key", "Vertex Keys", GH_ParamAccess.item, "");
            pManager.AddTextParameter("Edge Key", "Edge Key", "Edge Key", GH_ParamAccess.item, "");
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Path", "Path", "Path", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Declare a variable for the input String
            Topologic.Graph graph = null;
            Topologic.Vertex startVertex = null;
            Topologic.Vertex endVertex = null;
            String vertexKey = null;
            String edgeKey = null;

            // Use the DA object to retrieve the data inside the first input parameter.
            // If the retieval fails (for example if there is no data) we need to abort.
            if (!DA.GetData(0, ref graph)) { return; }
            if (!DA.GetData(1, ref startVertex)) { return; }
            if (!DA.GetData(2, ref endVertex)) { return; }
            if (!DA.GetData(3, ref vertexKey)) { return; }
            if (!DA.GetData(4, ref edgeKey)) { return; }

            // If the retrieved data is Nothing, we need to abort.
            // We're also going to abort on a zero-length String.
            if (graph == null) { return; }
            if (startVertex == null) { return; }
            if (endVertex == null) { return; }
            if (vertexKey == null) { return; }
            if (edgeKey == null) { return; }
            //if (data.Length == 0) { return; }

            // Convert the String to a character array.
            //char[] chars = data.ToCharArray();

            
            Topologic.Wire shortestPath = graph.ShortestPath(startVertex, endVertex, vertexKey, edgeKey);

            // Use the DA object to assign a new String to the first output parameter.
            DA.SetData(0, shortestPath);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return Resources.NMT_borderless_logo_small;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("bb430e8e-a452-45e1-9c13-24602c455c21"); }
        }
    }
}
