﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace TopologicGH
{
    public class CellUtilityContains: GH_Component
    {

        public CellUtilityContains()
          : base("CellUtility.Contains", "CellUtility.Contains", "Check if a vertex is contained in a Cell or not.", "TopologicUtilities", "CellUtility")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Cell", "Cell", "Cell", GH_ParamAccess.item);
            pManager.AddGenericParameter("Vertex", "Vertex", "Vertex", GH_ParamAccess.item);
            pManager.AddBooleanParameter("AllowOnBoundary", "AllowOnBoundary", "AllowOnBoundary", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddBooleanParameter("Bool", "Bool", "Bool", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs Not store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Declare a variable for the input String
            Topologic.Cell cell = null;
            Topologic.Vertex vertex = null;
            bool allowOnBoundary = false;

            // Use the DA object to retrieve the data inside the first input parameter.
            // If the retieval fails (for example if there is no data) we need to abort.
            if (!DA.GetData(0, ref cell)) { return; }
            if (!DA.GetData(1, ref vertex)) { return; }
            if (!DA.GetData(2, ref allowOnBoundary)) { return; }

            // If the retrieved data is Nothing, we need to abort.
            // We're also going to abort on a zero-length String.
            if (cell == null) { return; }
            if (vertex == null) { return; }
            //if (data.Length == 0) { return; }

            // Convert the String to a character array.
            //char[] chars = data.ToCharArray();

            
            bool isContained = Topologic.Utilities.CellUtility.Contains(cell, vertex, allowOnBoundary);

            // Use the DA object to assign a new String to the first output parameter.
            DA.SetData(0, isContained);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources Not access them like this:
                // return Resources.IconForThisComponent;
                return Resources.NMT_borderless_logo_small;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("8c92d34d-7322-41a5-9274-fe72077446c9"); }
        }
    }
}
