import { Component, ComponentFactoryResolver, Type, ViewChild, ComponentRef, ViewRef, ViewContainerRef} from '@angular/core';
// import { Router } from '@angular/router';

import { DynamicComponentService } from './common/DynamicDirectives/dynamic-component.service';
import { DynamicComponentDirective } from './common/DynamicDirectives/dynamic-component.directive';
// import { DynamicComponent } from './common/DynamicDirectives/dynamic-component';
import { IDynamicComponent } from './common/DynamicDirectives/dynamic-component.interface';

import { AuthenticationService } from './components/security/authentication.service';
import { User } from './components/security/user';
import { SessionInfo } from './components/security/sessionInfo';

import { ContainerComponent } from './common/DynamicDirectives/container/container.component';

@Component({
    selector: 'app-maestro-app',
    templateUrl: './app.component.html',
    styles: [`
      .full-height {
        height: 100%;
        width: 100%;
      }
      kendo-splitter + kendo-splitter { margin: 0px 0 0; }
      h3 { font-size: 1.2em; padding: 10px; }

      :host ::ng-deep .k-input{font-size:12px;}
      :host ::ng-deep .k-in{font-size:12px;}
      :host ::ng-deep .k-button{font-size:12px;}
      :host ::ng-deep .k-link{font-size:12px;}
      :host ::ng-deep kendo-formfield { font-size: 12px}
      :host ::ng-deep kendo-numerictextbox { font-size: 12px }
      :host ::ng-deep kendo-textbox { font-size: 12px}

    ` ]
})

export class AppComponent {

  currentUser: SessionInfo;
  public isAuthenticated: boolean;
  public currentComponentName: string;

  public selectedTabName: string = '';
  private currentPath: string;

  public treeNodes: any[] = [
    {
      menuName: 'Clients',
      path:'ClientList',
      subMenus: [
        { menuName: 'Wall Shelving', link:'11111' },
        { menuName: 'Floor Shelving', link: '22222' },
        { menuName: 'Kids Storage', link: '333333' }
      ]
    },
    {
      menuName: 'Purchases',
      path: 'PurchaseList',
      subMenus: [
        { menuName: 'Ceiling' },
        { menuName: 'Table' },
        { menuName: 'Floor' }
      ]
    },
    {
      menuName: 'Products',
      path: 'ProductList',
      subMenus: [
        { menuName: 'Ceiling' },
        { menuName: 'Table' },
        { menuName: 'Floor' }
      ]
    },
    {
      menuName: 'Sales',
      path: 'SaleList',
      subMenus: [
        { menuName: 'Ceiling' },
        { menuName: 'Table' },
        { menuName: 'Floor' }
      ]
    }

  ];

  public tabs: any[] = [];
  public componentRefs: ViewRef[] = [];

  public selectedTab: string = '';

  public handleNodeClick(event: any): void {

    var tabindex = this.tabs.findIndex(element => element.menuName == event.item.dataItem.menuName);

    this.selectedTab = event.item.dataItem.menuName;

    if (tabindex == -1) {
      console.log(event.item.dataItem.path);
      this.tabs.push(event.item.dataItem);
      this.currentComponentName = event.item.dataItem.path;
    }
    else {
      this.currentComponentName = event.item.dataItem.path;
    }

  }

  public onTabSelect(e) {
    this.selectedTab = this.tabs[e.index].menuName;
    this.currentComponentName = this.tabs[e.index].path;
  }

  public onTabCloseClick(index) {
    this.selectedTabName = "dddd: " +  JSON.stringify(index);

    this.tabs.splice(index, 1);
    this.destroyDynamicComponent(index); 

    var newIndex = index;

    if (this.tabs.length == 0)
    {
      this.selectedTab = '';
      return;
    }
    else
    {
      if (index > 0) newIndex = index - 1;
      this.selectedTab = this.tabs[newIndex].menuName;
    }

    this.currentComponentName = this.tabs[newIndex].path;
  }

//  constructor(private router: Router) {
  constructor(
    private authenticationService: AuthenticationService
  ) {
    this.isAuthenticated = false;
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);

    if (this.currentUser) 
      this.isAuthenticated = true;
    else
      this.isAuthenticated = false;
  }

  logout() {
    this.authenticationService.logout();
    this.isAuthenticated =  false;
  }

   onLoginSubmit(e) {
    if (this.currentUser)
      this.isAuthenticated = true;
    else
      this.isAuthenticated = false;
  }

    private destroyDynamicComponent(index) {

//    const viewContainerRef = this.DynamicComponentHost.viewContainer;
//    viewContainerRef.remove(index);

  }

}
