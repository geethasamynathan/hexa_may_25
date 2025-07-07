import React, { useEffect, useState } from "react";

export default function LifecycleFunctional() {
  const [count, setCount] = useState(0);

  useEffect(() => {
    console.log("useEffect (componentDidMount)");

    return () => {
      console.log("Cleanup (coponentWillUnmount");
    };
  }, []);

  useEffect(() => {
    if (count !== 0) {
      console.log("useEffect (ComponentDidupdate)- Count Changed");
    }
  }, [count]);

  return (
    <>
      <h2> LifeCycle Functional Component</h2>

      <h3> Count :{count}</h3>
      <button onClick={() => setCount(count + 1)}> Increment</button>
    </>
  );
}
