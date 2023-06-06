export class User {
  Id!: number;
  names: string;
  lastnames: string;
  birthdate: Date;
  password: string;
  gender: string;
  email: string;

  constructor(
    names: string,
    lastnames: string,
    birthdate: Date,
    password: string,
    gender: string,
    email: string
  ) {
    this.names = names;
    this.lastnames = lastnames;
    this.birthdate = birthdate;
    this.password = password;
    this.gender = gender;
    this.email = email;
  }
}
