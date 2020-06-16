/* ========================================================================
 * Copyright (c) 2005-2016 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;
using UAOOI.SemanticData.UANodeSetValidation.DataSerialization;

namespace Dependencies
{
    #region ObjectType Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <summary>
        /// The identifier for the SProduct ObjectType.
        /// </summary>
        public const uint SProduct = 1;

        /// <summary>
        /// The identifier for the SCart ObjectType.
        /// </summary>
        public const uint SCart = 58;

        /// <summary>
        /// The identifier for the SClient ObjectType.
        /// </summary>
        public const uint SClient = 60;
    }
    #endregion

    #region Variable Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <summary>
        /// The identifier for the SProduct_Id Variable.
        /// </summary>
        public const uint SProduct_Id = 53;

        /// <summary>
        /// The identifier for the SProduct_Author Variable.
        /// </summary>
        public const uint SProduct_Author = 54;

        /// <summary>
        /// The identifier for the SProduct_Price Variable.
        /// </summary>
        public const uint SProduct_Price = 55;

        /// <summary>
        /// The identifier for the SProduct_MinimalAge Variable.
        /// </summary>
        public const uint SProduct_MinimalAge = 56;

        /// <summary>
        /// The identifier for the SProduct_Name Variable.
        /// </summary>
        public const uint SProduct_Name = 57;

        /// <summary>
        /// The identifier for the SCart_Products Variable.
        /// </summary>
        public const uint SCart_Products = 59;

        /// <summary>
        /// The identifier for the SClient_Name Variable.
        /// </summary>
        public const uint SClient_Name = 61;

        /// <summary>
        /// The identifier for the SClient_Id Variable.
        /// </summary>
        public const uint SClient_Id = 62;

        /// <summary>
        /// The identifier for the SClient_Age Variable.
        /// </summary>
        public const uint SClient_Age = 63;

        /// <summary>
        /// The identifier for the SClient_LastName Variable.
        /// </summary>
        public const uint SClient_LastName = 64;

        /// <summary>
        /// The identifier for the SClient_Cart Variable.
        /// </summary>
        public const uint SClient_Cart = 65;
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <summary>
        /// The identifier for the SProduct ObjectType.
        /// </summary>
        public static readonly NodeId SProduct = new NodeId(Dependencies.ObjectTypes.SProduct);

        /// <summary>
        /// The identifier for the SCart ObjectType.
        /// </summary>
        public static readonly NodeId SCart = new NodeId(Dependencies.ObjectTypes.SCart);

        /// <summary>
        /// The identifier for the SClient ObjectType.
        /// </summary>
        public static readonly NodeId SClient = new NodeId(Dependencies.ObjectTypes.SClient);
    }
    #endregion

    #region Variable Node Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <summary>
        /// The identifier for the SProduct_Id Variable.
        /// </summary>
        public static readonly NodeId SProduct_Id = new NodeId(Dependencies.Variables.SProduct_Id);

        /// <summary>
        /// The identifier for the SProduct_Author Variable.
        /// </summary>
        public static readonly NodeId SProduct_Author = new NodeId(Dependencies.Variables.SProduct_Author);

        /// <summary>
        /// The identifier for the SProduct_Price Variable.
        /// </summary>
        public static readonly NodeId SProduct_Price = new NodeId(Dependencies.Variables.SProduct_Price);

        /// <summary>
        /// The identifier for the SProduct_MinimalAge Variable.
        /// </summary>
        public static readonly NodeId SProduct_MinimalAge = new NodeId(Dependencies.Variables.SProduct_MinimalAge);

        /// <summary>
        /// The identifier for the SProduct_Name Variable.
        /// </summary>
        public static readonly NodeId SProduct_Name = new NodeId(Dependencies.Variables.SProduct_Name);

        /// <summary>
        /// The identifier for the SCart_Products Variable.
        /// </summary>
        public static readonly NodeId SCart_Products = new NodeId(Dependencies.Variables.SCart_Products);

        /// <summary>
        /// The identifier for the SClient_Name Variable.
        /// </summary>
        public static readonly NodeId SClient_Name = new NodeId(Dependencies.Variables.SClient_Name);

        /// <summary>
        /// The identifier for the SClient_Id Variable.
        /// </summary>
        public static readonly NodeId SClient_Id = new NodeId(Dependencies.Variables.SClient_Id);

        /// <summary>
        /// The identifier for the SClient_Age Variable.
        /// </summary>
        public static readonly NodeId SClient_Age = new NodeId(Dependencies.Variables.SClient_Age);

        /// <summary>
        /// The identifier for the SClient_LastName Variable.
        /// </summary>
        public static readonly NodeId SClient_LastName = new NodeId(Dependencies.Variables.SClient_LastName);

        /// <summary>
        /// The identifier for the SClient_Cart Variable.
        /// </summary>
        public static readonly NodeId SClient_Cart = new NodeId(Dependencies.Variables.SClient_Cart);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the Age component.
        /// </summary>
        public const string Age = "Age";

        /// <summary>
        /// The BrowseName for the Author component.
        /// </summary>
        public const string Author = "Author";

        /// <summary>
        /// The BrowseName for the Cart component.
        /// </summary>
        public const string Cart = "Cart";

        /// <summary>
        /// The BrowseName for the Id component.
        /// </summary>
        public const string Id = "Id";

        /// <summary>
        /// The BrowseName for the LastName component.
        /// </summary>
        public const string LastName = "LastName";

        /// <summary>
        /// The BrowseName for the MinimalAge component.
        /// </summary>
        public const string MinimalAge = "MinimalAge";

        /// <summary>
        /// The BrowseName for the Name component.
        /// </summary>
        public const string Name = "Name";

        /// <summary>
        /// The BrowseName for the Price component.
        /// </summary>
        public const string Price = "Price";

        /// <summary>
        /// The BrowseName for the Products component.
        /// </summary>
        public const string Products = "Products";

        /// <summary>
        /// The BrowseName for the SCart component.
        /// </summary>
        public const string SCart = "SCart";

        /// <summary>
        /// The BrowseName for the SClient component.
        /// </summary>
        public const string SClient = "SClient";

        /// <summary>
        /// The BrowseName for the SProduct component.
        /// </summary>
        public const string SProduct = "SProduct";
    }
    #endregion

    #region Namespace Declarations
    /// <summary>
    /// Defines constants for all namespaces referenced by the model design.
    /// </summary>
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the ua namespace (.NET code namespace is 'Dependencies').
        /// </summary>
        public const string ua = "http://opcfoundation.org/UA/";
    }
    #endregion

}