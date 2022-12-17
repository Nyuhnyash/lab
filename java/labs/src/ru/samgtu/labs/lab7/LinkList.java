package ru.samgtu.labs.lab7;

import java.util.Iterator;

public class LinkList<E> implements Iterable<E>{
    public ListItem<E> head;

    public void add(E data) {
        if (head == null) {
            head = new ListItem<>(data);
            return;
        }

        var e = head;

        do {
            e = e.next;
        } while (e.next != null);
        e.next = new ListItem<>(data);
    }

    public void add(int index, E element) {
        if (index == 0) {
            var e = new ListItem<>(element);
            e.next = head;
            head = e;
            return;
        }

        var e = head;
        for (int i = 0; i < index - 1; i++) {
            e = e.next;
        }
        var next = e.next;
        e.next = new ListItem<>(element);
        e.next.next = next;
    }

    public E get(int index) {
        var e = head;
        for (int i = 0; i < index; i++) {
            e = e.next;
        }
        return e.data;
    }

    public void set(int index, E element) {
        var e = head;
        for (int i = 0; i < index; i++) {
            e = e.next;
        }
        e.data = element;
    }

    public void remove(int index) {
        if (index == 0) {
            head = head.next;
            return;
        }

        var e = head;
        for (int i = 0; i < index - 1; i++) {
            e = e.next;
        }
        e.next = e.next.next;
    }

    public int size() {
        if (head == null) {
            return 0;
        }

        var e = head;
        var size = 1;
        while (e.next != null) {
            e = e.next;
            size++;
        }
        return size;
    }

    public boolean isEmpty() {
        return head == null;
    }

    public void clear() {
        head = null;
    }

    @Override
    public Iterator<E> iterator() {
        return new Iterator<>() {
            private ListItem<E> e = head;

            @Override
            public boolean hasNext() {
                return e != null;
            }

            @Override
            public E next() {
                var data = e.data;
                e = e.next;
                return data;
            }
        };
    }

    private static class ListItem<T> {
        private ListItem<T> next;
        private T data;

        public ListItem(T data) {
            this.data = data;
        }
    }
}
