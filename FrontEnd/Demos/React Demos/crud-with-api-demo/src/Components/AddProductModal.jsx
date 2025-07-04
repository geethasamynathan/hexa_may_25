import React from "react";
import ProductForm from "./ProductForm";

export default function AddProductModal({ show, onClose, onSubmit }) {
  return (
    <div className={`modal fade ${show ? "show d-block" : ""}`} tabIndex="-1">
      <div className="modal-dialog">
        <div className="modal-content">
          <div className="modal-header">
            <h5 className="modal-title">Add Product</h5>
            <button className="btn-close" onClick={onClose}></button>
          </div>
          <div className="modal-body">
            <ProductForm product={null} onSubmit={onSubmit} onCancel={onClose} />
          </div>
        </div>
      </div>
    </div>
  );
}
