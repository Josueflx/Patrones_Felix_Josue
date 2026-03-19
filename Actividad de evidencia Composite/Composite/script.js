class Componente {
  constructor(nombre) {
    this._nombre = nombre;
  }

  get nombre() {
    return this._nombre;
  }

  agregarHijo(c) {
    throw new Error("Método no implementado");
  }

  obtenerHijos() {
    throw new Error("Método no implementado");
  }

  get obtenerPrecio() {
    throw new Error("Getter no implementado");
  }

  get tipo() {
    return "Componente";
  }
}

class Producto extends Componente {
  constructor(nombre, precio, categoria, icono, descripcion) {
    super(nombre);
    this._precio = precio;
    this.categoria = categoria;
    this.icono = icono;
    this.descripcion = descripcion;
  }

  agregarHijo(c) {
    console.warn("Un producto no puede tener hijos");
  }

  obtenerHijos() {
    return [];
  }

  get obtenerPrecio() {
    return this._precio;
  }

  get tipo() {
    return "Producto";
  }
}

class ComboPC extends Componente {
  constructor(nombre, descripcion) {
    super(nombre);
    this.descripcion = descripcion;
    this._hijos = [];
  }

  agregarHijo(c) {
    this._hijos.push(c);
  }

  obtenerHijos() {
    return this._hijos;
  }

  get obtenerPrecio() {
    return this._hijos.reduce((acc, item) => acc + item.obtenerPrecio, 0);
  }

  get tipo() {
    return "Combo";
  }
}

const productos = [
  new Producto("Ryzen 7 7800X3D", 8999, "Procesador", "🧠", "Excelente rendimiento para gaming y multitarea."),
  new Producto("RTX 4070 Super", 14999, "Tarjeta gráfica", "🎮", "GPU ideal para 1440p y alta tasa de FPS."),
  new Producto("RAM 32GB DDR5", 2899, "Memoria RAM", "⚡", "Mayor fluidez para juegos y trabajo pesado."),
  new Producto("SSD NVMe 1TB", 1699, "Almacenamiento", "💾", "Cargas rápidas para sistema y juegos."),
  new Producto("Motherboard B650", 3499, "Tarjeta madre", "🔌", "Base confiable para plataforma AM5."),
  new Producto("Fuente 750W Gold", 1999, "Fuente de poder", "🔋", "Energía estable y eficiente."),
  new Producto("Gabinete Airflow RGB", 1799, "Gabinete", "🖥️", "Buen flujo de aire y estética gamer."),
  new Producto("Monitor 24 144Hz", 4199, "Monitor", "📺", "Experiencia más fluida para gaming."),
];

const comboGamer = new ComboPC("PC Gamer Pro", "Build enfocada en gaming de alto rendimiento");
comboGamer.agregarHijo(productos[0]);
comboGamer.agregarHijo(productos[1]);
comboGamer.agregarHijo(productos[2]);
comboGamer.agregarHijo(productos[3]);
comboGamer.agregarHijo(productos[4]);
comboGamer.agregarHijo(productos[5]);
comboGamer.agregarHijo(productos[6]);

const comboOficina = new ComboPC("PC Oficina Plus", "Build equilibrada para trabajo y productividad");
comboOficina.agregarHijo(new Producto("Ryzen 5 5600G", 3299, "Procesador", "🧠", "Procesador con gráficos integrados."));
comboOficina.agregarHijo(new Producto("RAM 16GB DDR4", 1299, "Memoria RAM", "⚡", "Capacidad adecuada para oficina."));
comboOficina.agregarHijo(new Producto("SSD 500GB", 899, "Almacenamiento", "💾", "Velocidad y espacio básico."));
comboOficina.agregarHijo(new Producto("Motherboard B550", 2299, "Tarjeta madre", "🔌", "Plataforma sólida para oficina."));
comboOficina.agregarHijo(new Producto("Fuente 550W", 999, "Fuente de poder", "🔋", "Suficiente para esta configuración."));
comboOficina.agregarHijo(new Producto("Gabinete compacto", 1099, "Gabinete", "🖥️", "Diseño limpio para escritorio."));

const comboStreaming = new ComboPC("PC Streaming Creator", "Pensada para gaming, edición y transmisión");
comboStreaming.agregarHijo(new Producto("Intel i7 14700K", 9499, "Procesador", "🧠", "Excelente para multitarea avanzada."));
comboStreaming.agregarHijo(new Producto("RTX 4070 Ti", 18999, "Tarjeta gráfica", "🎮", "Potencia gráfica para creación."));
comboStreaming.agregarHijo(new Producto("RAM 64GB DDR5", 4999, "Memoria RAM", "⚡", "Ideal para edición y streaming."));
comboStreaming.agregarHijo(new Producto("SSD NVMe 2TB", 2999, "Almacenamiento", "💾", "Espacio amplio y gran velocidad."));
comboStreaming.agregarHijo(new Producto("Motherboard Z790", 4999, "Tarjeta madre", "🔌", "Mayor capacidad de expansión."));
comboStreaming.agregarHijo(new Producto("Fuente 850W Gold", 2699, "Fuente de poder", "🔋", "Más margen para alto consumo."));
comboStreaming.agregarHijo(new Producto("Gabinete premium", 2499, "Gabinete", "🖥️", "Espacio y enfriamiento mejorados."));

const combos = [comboGamer, comboOficina, comboStreaming];
const carrito = new ComboPC("Carrito", "Contenedor principal del carrito");

function formatoMoneda(valor) {
  return new Intl.NumberFormat("es-MX", {
    style: "currency",
    currency: "MXN"
  }).format(valor);
}

function crearCardProducto(producto) {
  return `
    <article class="card">
      <div class="product-image">${producto.icono}</div>
      <div class="card-body">
        <div class="small-note">${producto.categoria}</div>
        <div class="card-title">${producto.nombre}</div>
        <div class="card-desc">${producto.descripcion}</div>
        <div class="price">${formatoMoneda(producto.obtenerPrecio)}</div>
        <div class="card-actions">
          <button class="btn" onclick="agregarAlCarritoProducto('${producto.nombre}')">Agregar</button>
          <button class="btn-outline">Detalles</button>
        </div>
      </div>
    </article>
  `;
}

function crearCardCombo(combo) {
  return `
    <article class="card">
      <div class="product-image">🛒</div>
      <div class="card-body">
        <div class="small-note">Build completa · Composite</div>
        <div class="card-title">${combo.nombre}</div>
        <div class="card-desc">${combo.descripcion}</div>
        <div class="small-note">${combo.obtenerHijos().length} componentes incluidos</div>
        <div class="price">${formatoMoneda(combo.obtenerPrecio)}</div>
        <div class="card-actions">
          <button class="btn" onclick="agregarAlCarritoCombo('${combo.nombre}')">Agregar combo</button>
          <button class="btn-outline" onclick="verCombo('${combo.nombre}')">Ver piezas</button>
        </div>
      </div>
    </article>
  `;
}

function renderProductos() {
  const grid = document.getElementById("productosGrid");
  grid.innerHTML = productos.map(crearCardProducto).join("");
}

function renderCombos() {
  const grid = document.getElementById("buildsGrid");
  grid.innerHTML = combos.map(crearCardCombo).join("");
}

function agregarAlCarritoProducto(nombre) {
  const producto = productos.find(p => p.nombre === nombre);
  if (producto) {
    carrito.agregarHijo(producto);
    renderCarrito();
  }
}

function agregarAlCarritoCombo(nombre) {
  const combo = combos.find(c => c.nombre === nombre);
  if (combo) {
    carrito.agregarHijo(combo);
    renderCarrito();
  }
}

function agregarComboDestacado() {
  carrito.agregarHijo(comboGamer);
  renderCarrito();
}

function vaciarCarrito() {
  carrito._hijos = [];
  renderCarrito();
}

function verCombo(nombre) {
  const combo = combos.find(c => c.nombre === nombre);
  if (!combo) return;

  const piezas = combo.obtenerHijos()
    .map(h => `• ${h.nombre} - ${formatoMoneda(h.obtenerPrecio)}`)
    .join("\n");

  alert(`${combo.nombre}\n\n${piezas}\n\nTotal: ${formatoMoneda(combo.obtenerPrecio)}`);
}

function renderCarrito() {
  const contenedor = document.getElementById("cartItems");
  const hijos = carrito.obtenerHijos();

  if (hijos.length === 0) {
    contenedor.innerHTML = `<div class="empty">Tu carrito está vacío.</div>`;
  } else {
    contenedor.innerHTML = hijos.map((item) => {
      const extra = item.tipo === "Combo"
        ? `${item.obtenerHijos().length} productos dentro`
        : item.categoria || "Producto";

      return `
        <div class="cart-item">
          <div class="cart-item-header">
            <div>
              <div class="cart-item-title">${item.nombre}</div>
              <div class="cart-item-type">${item.tipo} · ${extra}</div>
            </div>
            <div class="price" style="font-size: 1rem;">${formatoMoneda(item.obtenerPrecio)}</div>
          </div>
        </div>
      `;
    }).join("");
  }

  const subtotal = carrito.obtenerPrecio;
  const envio = 250;
  const total = subtotal + envio;

  document.getElementById("subtotal").textContent = formatoMoneda(subtotal);
  document.getElementById("envio").textContent = formatoMoneda(envio);
  document.getElementById("totalFinal").textContent = formatoMoneda(total);

  renderTree();
  imprimirResumenConsola();
}

function renderTree() {
  const contenedor = document.getElementById("treeView");
  const hijos = carrito.obtenerHijos();

  if (hijos.length === 0) {
    contenedor.innerHTML = `<div class="empty">No hay estructura que mostrar todavía.</div>`;
    return;
  }

  const ul = document.createElement("ul");
  ul.appendChild(renderNodo(carrito));
  contenedor.innerHTML = "";
  contenedor.appendChild(ul);
}

function renderNodo(componente) {
  const li = document.createElement("li");
  const hijos = componente.obtenerHijos();
  const esCompuesto = hijos.length > 0;

  const div = document.createElement("div");
  div.className = "tree-node";
  div.innerHTML = `
    <div class="tree-left">
      <strong>${componente.nombre}</strong>
      <small>${componente.tipo}${esCompuesto ? " con hijos" : " individual"}</small>
    </div>
    <div><strong>${formatoMoneda(componente.obtenerPrecio)}</strong></div>
  `;

  li.appendChild(div);

  if (esCompuesto) {
    const ul = document.createElement("ul");
    hijos.forEach(h => ul.appendChild(renderNodo(h)));
    li.appendChild(ul);
  }

  return li;
}

function imprimirResumenConsola() {
  console.clear();
  console.log(`El total del carrito ${carrito.nombre} es ${carrito.obtenerPrecio}`);
  carrito.obtenerHijos().forEach(item => {
    console.log(`- ${item.tipo}: ${item.nombre} = ${item.obtenerPrecio}`);
  });
}

renderProductos();
renderCombos();
renderCarrito();