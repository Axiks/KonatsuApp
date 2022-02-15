import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Habit } from './habit';

@Injectable()
export class DataService {

  private url = "/api/habits";

  constructor(private http: HttpClient) {
  }

  getHabits() {
    return this.http.get(this.url);
  }

  getHabit(id: string) {
    return this.http.get(this.url + '/' + id);
  }

  createHabit(habit: Habit) {
    return this.http.post(this.url, habit);
  }
  updateHabit(habit: Habit) {

    return this.http.put(this.url, habit);
  }
  deleteHabit(id: string) {
    return this.http.delete(this.url + '/' + id);
  }
}
