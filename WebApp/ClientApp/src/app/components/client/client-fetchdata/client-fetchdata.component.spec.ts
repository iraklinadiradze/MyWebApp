/// <reference path="../../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ClientFetchDataComponent} from './client-fetchdata.component';

let component: ClientFetchDataComponent;
let fixture: ComponentFixture<ClientFetchDataComponent>;

describe('ClientFilter component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
          declarations: [ClientFetchDataComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
      fixture = TestBed.createComponent(ClientFetchDataComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
