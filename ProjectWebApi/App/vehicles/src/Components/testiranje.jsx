import React from 'react';
import ReactDom from 'react-dom'

function testiranje() {
    return ReactDom.createPortal(
        <div>
          <h1>haj</h1>  
        </div>,
        document.getElementById("portal-root")
    )
}

export default testiranje;
