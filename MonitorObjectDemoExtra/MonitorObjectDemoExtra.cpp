#include <iostream>
#include <thread>
#include <mutex>
#include <chrono>
#include <windows.h>

class Counter {
private:
    int count = 0;
    std::mutex mtx;

public:
    void Increment(const std::string& threadName) {
        std::lock_guard<std::mutex> lock(mtx);
        std::cout << threadName << " → Збільшує лічильник..." << std::endl;
        int temp = count;
        std::this_thread::sleep_for(std::chrono::milliseconds(100));
        count = temp + 1;
        std::cout << threadName << " → Поточне значення: " << count << std::endl;
    }
};

void threadFunction(Counter& counter, const std::string& name) {
    counter.Increment(name);
}

int main() {
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);

    std::cout << "Демонстрація шаблону Monitor Object (C++):\n" << std::endl;

    Counter counter;

    std::thread t1(threadFunction, std::ref(counter), "Потік 1");
    std::thread t2(threadFunction, std::ref(counter), "Потік 2");
    std::thread t3(threadFunction, std::ref(counter), "Потік 3");

    t1.join();
    t2.join();
    t3.join();

    return 0;
}
