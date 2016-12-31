
-- Add MODEL3D as item view type
if ( not exists ( select 1 from SobekCM_Item_Viewer_Types where ViewType = 'MODEL3D' ))
begin
	
	insert into SobekCM_Item_Viewer_Types ( ViewType, [Order], DefaultView, MenuOrder )
	values ( 'MODEL3D', 1, 0, 99 );

end;
GO
