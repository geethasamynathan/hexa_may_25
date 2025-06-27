import react from "react";
import { useState } from "react";

function Home() {
  return (
    <div>
      <header>
        <h1>Geetha Website</h1>
        <h2>welcome to Home page</h2>
      </header>

      <nav>
        <ul>
          <li>
            <a href="#"> 🏡Home</a>
          </li>
          <li>
            <a href="#">🗒️About</a>
          </li>
          <li>
            <a href="#">⚓Services </a>
          </li>
          <li>
            <a href="#">📞Contact</a>{" "}
          </li>
        </ul>
      </nav>
    </div>
  );
}

export default Home;
