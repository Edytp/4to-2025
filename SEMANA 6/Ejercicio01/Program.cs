#include <iostream>
#include <cstdlib>
#include <ctime>

struct Nodo {
    int dato;
    Nodo* siguiente;
    Nodo(int valor) : dato(valor), siguiente(nullptr) {}
};

class ListaEnlazada {
private:
    Nodo* cabeza;

public:
    ListaEnlazada() : cabeza(nullptr) {}

    void insertar(int valor) {
        Nodo* nuevoNodo = new Nodo(valor);
        nuevoNodo->siguiente = cabeza;
        cabeza = nuevoNodo;
    }

    void imprimir() const {
        Nodo* actual = cabeza;
        while (actual) {
            std::cout << actual->dato << " ";
            actual = actual->siguiente;
        }
        std::cout << std::endl;
    }

    void eliminarFueraDeRango(int min, int max) {
        Nodo* actual = cabeza;
        Nodo* anterior = nullptr;

        while (actual) {
            if (actual->dato < min || actual->dato > max) {
                if (anterior) {
                    anterior->siguiente = actual->siguiente;
                } else {
                    cabeza = actual->siguiente;
                }
                Nodo* temp = actual;
                actual = actual->siguiente;
                delete temp;
            } else {
                anterior = actual;
                actual = actual->siguiente;
            }
        }
    }

    ~ListaEnlazada() {
        Nodo* actual = cabeza;
        while (actual) {
            Nodo* siguiente = actual->siguiente;
            delete actual;
            actual = siguiente;
        }
    }
};

int main() {
    srand(time(0)); // Inicializa la semilla para números aleatorios

    ListaEnlazada lista;
    for (int i = 0; i < 50; ++i) {
        int va
