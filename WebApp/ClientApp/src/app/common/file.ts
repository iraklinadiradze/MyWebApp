export class ClientType {
  constructor() {
    this.Client = new HashSet<Client>();
  }
  public Id: number;
  public ClientTypeName: string;
  public Client: ICollection<Client>;
}
