import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public persons: PersonViewModel[] = [];

  constructor(http: HttpClient) {
    http.get<PersonViewModel[]>("https://localhost:7090/" + 'api/Persons/GetAll').subscribe(result => {
      this.persons = result;
    }, error => console.error(error));
  }
}

interface PersonViewModel {
  int: number;
  name: string;
  surname: string;
  address: string;
  emailAddress: string;
}
