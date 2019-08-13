﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace TopologicGH
{
    public class FaceAddInternalBoundaries : GH_Component
    {

        public FaceAddInternalBoundaries()
          : base("Face.AddInternalBoundaries", "Face.AddInternalBoundaries", "Adds internal boundaries (Wires) to a Face.", "Topologic", "Face")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Face", "Face", "Face", GH_ParamAccess.item);
            pManager.AddGenericParameter("Internal Boundaries", "Internal Boundaries", "Internal Boundaries", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Face", "Face", "Face", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // Declare a variable for the input String
            Topologic.Face face = null;
            List<Topologic.Wire> internalBoundaries = new List<Topologic.Wire>();

            // Use the DA object to retrieve the data inside the first input parameter.
            // If the retieval fails (for example if there is no data) we need to abort.
            if (!DA.GetData(0, ref face)) { return; }
            if (!DA.GetDataList(1, internalBoundaries)) { return; }

            // If the retrieved data is Nothing, we need to abort.
            // We're also going to abort on a zero-length String.
            if (face == null) { return; }
            if (internalBoundaries == null) { return; }
            //if (data.Length == 0) { return; }

            // Convert the String to a character array.
            //char[] chars = data.ToCharArray();

            
            Topologic.Face newFace = face.AddInternalBoundaries(internalBoundaries);

            // Use the DA object to assign a new String to the first output parameter.
            DA.SetData(0, newFace);
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
            get { return new Guid("cd3ba686-dc64-43bf-9cd0-cafb9258fe5f"); }
        }
    }
}
